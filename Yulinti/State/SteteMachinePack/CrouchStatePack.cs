using UnityEngine;
using Animancer;

using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    
    public sealed class CrouchStatePack : IStatePack {
        private readonly MoveTuning _moveTuning;
        private readonly InputProvider _inputProvider;
        private readonly CameraProvider _cameraProvider;
        private readonly CrouchIdleStateConfig _crouchIdleStateConfig;
        private readonly CrouchWalkStateConfig _crouchWalkStateConfig;
        private readonly CrouchAnimationConfig _crouchAnimationConfig;
        private readonly AnimancerComponent _animancer;

        private enum LocalStateID {
            Idle, Walk
        }

        private static readonly Dictionary<LocalStateID, StateID> _Map = new Dictionary<LocalStateID, StateID> {
            { LocalStateID.Idle, StateID.CrouchIdle },
            { LocalStateID.Walk, StateID.CrouchWalk },
        };

        public CrouchStatePack(
            MoveTuning moveTuning,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
            CrouchStateConfig crouchStateConfig,
            AnimancerComponent animancer
        ) {
            _moveTuning = moveTuning;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
            _crouchIdleStateConfig = crouchStateConfig.CrouchIdleStateConfig;
            _crouchWalkStateConfig = crouchStateConfig.CrouchWalkStateConfig;
            _crouchAnimationConfig = crouchStateConfig.CrouchAnimationConfig;
            _animancer = animancer;
        }

        public void Apply(StateMachine stateMachine) {
            IMoveState crouchIdleState = BuildCrouchIdleState();
            IMoveState crouchWalkState = BuildCrouchWalkState();
            IAnimationPlan crouchAnimation = BuildCrouchAnimation();
            stateMachine.AddState(_Map[LocalStateID.Idle], new StateContainer { State = crouchIdleState, AnimationPlan = crouchAnimation });
            stateMachine.AddState(_Map[LocalStateID.Walk], new StateContainer { State = crouchWalkState, AnimationPlan = crouchAnimation });
        }

        private CrouchIdleState BuildCrouchIdleState() {
            CrouchIdleState crouchIdleState = new CrouchIdleState(
                _moveTuning,
                _crouchIdleStateConfig,
                _inputProvider
            );
            return crouchIdleState;
        }
        private CrouchWalkState BuildCrouchWalkState() {
            CrouchWalkState crouchWalkState = new CrouchWalkState(
                _moveTuning,
                _crouchWalkStateConfig,
                _inputProvider,
                _cameraProvider
            );
            return crouchWalkState;
        }
        private SpeedInjectableTPAnimationPlan BuildCrouchAnimation() {
            IAnimationFacade crouchMixer = new AnimationPlayerSpeedInjectable(
                _animancer,
                _crouchAnimationConfig.CrouchAnimationMixer,
                _crouchAnimationConfig.FadeTime, Easing.Cubic.InOut
            );
            SpeedInjectableTPAnimationPlan crouchAnimation = new SpeedInjectableTPAnimationPlan(
                null, crouchMixer, null, 1
            );
            return crouchAnimation;
        }
    }
}