using UnityEngine;
using Animancer;

using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class BaseStatePack : IStatePack {
        private readonly StateConfigCommon _stateConfigCommon;
        private readonly InputProvider _inputProvider;
        private readonly CameraProvider _cameraProvider;
        private readonly IdleStateConfig _idleStateConfig;
        private readonly WalkStateConfig _walkStateConfig;
        private readonly RunStateConfig _runStateConfig;
        private readonly BaseAnimationConfig _baseAnimationConfig;
        private readonly AnimancerComponent _animancer;

        public BaseStatePack(
            StateConfigCommon stateConfigCommon,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
            BaseStateConfig baseStateConfig,
            AnimancerComponent animancer
        ) {
            _stateConfigCommon = stateConfigCommon;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
            _idleStateConfig = baseStateConfig.IdleStateConfig;
            _walkStateConfig = baseStateConfig.WalkStateConfig;
            _runStateConfig = baseStateConfig.RunStateConfig;
            _baseAnimationConfig = baseStateConfig.BaseAnimationConfig;
            _animancer = animancer;
        }

        private enum LocalStateID {
            Idle, Walk, Run
        }

        private static readonly Dictionary<LocalStateID, StateID> _Map = new Dictionary<LocalStateID, StateID> {
            { LocalStateID.Idle, StateID.Idle },
            { LocalStateID.Walk, StateID.Walk },
            { LocalStateID.Run, StateID.Run },
        };

        public void Apply(StateMachine stateMachine) {
            IMoveState idleState = BuildIdleState();
            IMoveState walkState = BuildWalkState();
            IMoveState runState = BuildRunState();
            IAnimationPlan baseAnimation = BuildBaseAnimation();
            stateMachine.AddState(_Map[LocalStateID.Idle], new StateContainer { State = idleState, AnimationPlan = baseAnimation });
            stateMachine.AddState(_Map[LocalStateID.Walk], new StateContainer { State = walkState, AnimationPlan = baseAnimation });
            stateMachine.AddState(_Map[LocalStateID.Run], new StateContainer { State = runState, AnimationPlan = baseAnimation });
        }

        private IdleState BuildIdleState() {
            IdleState idleState = new IdleState(
                _idleStateConfig,
                _stateConfigCommon,
                _inputProvider
            );
            return idleState;
        }
        private WalkState BuildWalkState() {
            WalkState walkState = new WalkState(
                _walkStateConfig,
                _stateConfigCommon,
                _inputProvider,
                _cameraProvider
            );
            return walkState;
        }
        private RunState BuildRunState() {
            RunState runState = new RunState(
                _runStateConfig,
                _stateConfigCommon,
                _inputProvider,
                _cameraProvider
            );
            return runState;
        }
        private LayerZeroAnimationPlan BuildBaseAnimation() {
            SpeedInjectableOPAnimationPlayer opAnimationPlayer = new SpeedInjectableOPAnimationPlayer(
                _animancer,
                _baseAnimationConfig.BaseAnimationMixer,
                0
            );
            LayerZeroAnimationPlan baseAnimation = new LayerZeroAnimationPlan(
                opAnimationPlayer
            );
            return baseAnimation;
        }
    }
}