using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class PlayerController {
        private readonly PlayerConfig _playerConfig;
        private readonly StateMachine _stateMachine;
        private readonly PlayerMover _mover;
        private readonly FukaSkinConstraint _fukaSkinConstraint;

        private readonly MoveInputProvider _moveInputProvider;
        private readonly CameraProvider _cameraProvider;

        private MoveRuntime _moveRuntime;
        private MoveRuntimeReadOnly _moveRuntimeRO;
        private MoveRuntimeCommands _moveRuntimeCmds;

        public PlayerController(
            PlayerConfig playerConfig,
            MoveInputProvider inputProvider,
            CameraProvider cameraProvider,
            FrameContext frameContext
        ) {
            if (playerConfig == null || inputProvider == null || cameraProvider == null) {
                Debug.LogError("PlayerConfig or InputProvider or CameraProvider is null");
                return;
            }
            _playerConfig = playerConfig;
            _moveInputProvider = inputProvider;
            _cameraProvider = cameraProvider;

            _fukaSkinConstraint = BuildFukaSkinConstraint();
            _stateMachine = BuildStateMachine();
            _mover = BuildMover();

            BuildMoveRuntime(frameContext);
        }

        private void BuildMoveRuntime(FrameContext frameContext) {
            _moveRuntime = new MoveRuntime(
                frameContext,
                0f, 0f, 0f, true
            );
            _moveRuntimeRO = new MoveRuntimeReadOnly(_moveRuntime);
            _moveRuntimeCmds = new MoveRuntimeCommands(_moveRuntime);
        }

        private StateMachine BuildStateMachine() {
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

            return stateMachine;
        }

        private PlayerMover BuildMover()
        {
            PlayerMover mover = new PlayerMover(
                _playerConfig.MoverConfig,
                _playerConfig.GrounderConfig
            );

            return mover;
        }

        private FukaSkinConstraint BuildFukaSkinConstraint()
        {
            FukaSkinConstraint fukaSkinConstraint = new FukaSkinConstraint(
                _playerConfig.FukaSkinConstraintConfig
            );

            return fukaSkinConstraint;
        }

        public void Initialize() {
            _stateMachine.Initialize(_moveRuntimeRO);
        }

        public void Tick(
            PlayerRuntimeReadOnly playerRuntimeRO,
            PlayerRuntimeCommands playerRuntimeCmds
        ) {
            MovePlan movePlan = _stateMachine.PlanMove(_moveRuntimeRO);
            _mover.Tick(movePlan, _moveRuntimeCmds, _moveRuntimeRO);
            _stateMachine.PostMove(_moveRuntimeRO);
            _stateMachine.TryTransition(_moveRuntimeRO);

            // PlayerRuntimeを更新
            playerRuntimeCmds.ApplyMoveRuntime(_moveRuntimeRO);
            playerRuntimeCmds.ApplyStateID(_stateMachine.CurrentStateID);
        }

        public void LateTick() {
            _fukaSkinConstraint.ApplyAll();
            _mover.LateTick();
        }
    }
}