using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class PlayerController {
        private readonly PlayerConfig _playerConfig;
        private readonly StateMachine _stateMachine;
        private readonly Mover _mover;

        private readonly MoveInputProvider _moveInputProvider;
        private readonly CameraProvider _cameraProvider;

        private MoveRuntime _moveRuntime;
        private MoveRuntimeReadOnly _moveRuntimeRO;
        private MoveRuntimeWriteable _moveRuntimeRW;

        public PlayerController(
            PlayerConfig playerConfig,
            MoveInputProvider inputProvider,
            CameraProvider cameraProvider
        ) {
            _playerConfig = playerConfig;
            _moveInputProvider = moveInputProvider;
            _cameraProvider = cameraProvider;

            BuildStateMachine();
            BuildMoveRuntime();
            BuildMover();
        }

        private void BuildMoveRuntime() {
            _moveRuntime = new MoveRuntime(
                0f, 0f, 0f, 0f, true
            );
            _moveRuntimeRO = new MoveRuntimeReadOnly(_moveRuntime);
            _moveRuntimeRW = new MoveRuntimeWriteable(_moveRuntime);
        }

        private void BuildStateMachine() {
            StateMachine stateMachine = new StateMachine();

            IStatePack baseStatePack = new BaseStatePack(
                _playerConfig.StateConfigCommon,
                _moveInputProvider,
                _cameraProvider,
                _playerConfig.StateConfig.BaseStateConfig,
                _playerConfig.AnimationConfigCommon.Animancer
            );

            IStatePack crouchStatePack = new CrouchStatePack(
                _playerConfig.StateConfigCommon,
                _moveInputProvider,
                _cameraProvider,
                _playerConfig.StateConfig.CrouchStateConfig,
                _playerConfig.AnimationConfigCommon.Animancer
            );

            baseStatePack.Apply(stateMachine);
            crouchStatePack.Apply(stateMachine);
        }

        private void BuildMover() {
            _mover = new Mover(
                _playerConfig.MoverConfig
            );
        }

        public void Initialize() {
            _stateMachine.Initialize(_moveRuntimeRO);
        }

        public void Tick(
            PlayerRuntimeReadOnly playerRuntimeRO,
            PlayerRuntimeCommands playerRuntimeWO
        ) {
            // DeltaTimeを更新
            _moveRuntime.DeltaTime = playerRuntimeRO.DeltaTime;
            
            MovePlan movePlan = _stateMachine.PlanMove(_moveRuntimeRO);
            _mover.Tick(movePlan, _moveRuntimeRW, _moveRuntimeRO);
            _stateMachine.PostMove(_moveRuntimeRO);
            _stateMachine.TryTransition(_moveRuntimeRO);

            // PlayerRuntimeを更新
            playerRuntimeWO.ApplyMoveRuntime(_moveRuntimeRO);
            playerRuntimeWO.ApplyStateID(_stateMachine.CurrentStateID);
        }

        public void LateTick() {
            _mover.LateTick();
        }
    }
}