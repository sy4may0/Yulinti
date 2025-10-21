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
            CrouchIdleStateConfig crouchIdleStateConfig,
            CrouchWalkStateConfig crouchWalkStateConfig,
            CrouchAnimationConfig crouchAnimationConfig,
            AnimancerComponent animancer
        ) {
            _moveTuning = moveTuning;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
            _crouchIdleStateConfig = crouchIdleStateConfig;
            _crouchWalkStateConfig = crouchWalkStateConfig;
            _crouchAnimationConfig = crouchAnimationConfig;
            _animancer = animancer;
        }

        public void Apply(StateMachine stateMachine) {
            IMoveState crouchIdleState = BuildCrouchIdleState();
            IMoveState crouchWalkState = BuildCrouchWalkState();
            IAnimationPlan crouchAnimation = BuildCrouchAnimation();
            stateMachine.AddState(_Map[LocalStateID.Idle], crouchIdleState, crouchAnimation);
            stateMachine.AddState(_Map[LocalStateID.Walk], crouchWalkState, crouchAnimation);
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
            SpeedInjectableTPAnimationPlan crouchAnimation = new SpeedInjectableTPAnimationPlan(
                _animancer,
                1,
                null, _crouchAnimationConfig.CrouchAnimationMixer, null,
                _crouchAnimationConfig.FadeTime,
                _crouchAnimationConfig.FadeTime,
                _crouchAnimationConfig.FadeTime
            );
            return crouchAnimation;
        }
    }
}