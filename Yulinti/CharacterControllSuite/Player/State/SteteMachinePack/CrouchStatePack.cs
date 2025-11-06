using UnityEngine;
using Animancer;
using System.Collections.Generic;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    
    public sealed class CrouchStatePack : IStatePack {
        private readonly PlayerStateConfigCommon _stateConfigCommon;
        private readonly MoveInputProvider _inputProvider;
        private readonly CameraProvider _cameraProvider;
        private readonly PlayerCrouchIdleStateConfig _crouchIdleStateConfig;
        private readonly PlayerCrouchWalkStateConfig _crouchWalkStateConfig;
        private readonly PlayerCrouchAnimationConfig _crouchAnimationConfig;
        private readonly AnimancerComponent _animancer;
        private readonly int _crouchLayerIndex = 1;

        private enum LocalStateID {
            Idle, Walk
        }

        private static readonly Dictionary<LocalStateID, StateID> _Map = new Dictionary<LocalStateID, StateID> {
            { LocalStateID.Idle, StateID.CrouchIdle },
            { LocalStateID.Walk, StateID.CrouchWalk },
        };

        public CrouchStatePack(
            PlayerStateConfigCommon stateConfigCommon,
            MoveInputProvider inputProvider,
            CameraProvider cameraProvider,
            PlayerCrouchStateConfig crouchStateConfig,
            AnimancerComponent animancer
        ) {
            _stateConfigCommon = stateConfigCommon;
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
            stateMachine.AddState(_Map[LocalStateID.Idle], new StateContainer(crouchIdleState, crouchAnimation));
            stateMachine.AddState(_Map[LocalStateID.Walk], new StateContainer(crouchWalkState, crouchAnimation));
        }

        private CrouchIdleState BuildCrouchIdleState() {
            CrouchIdleState crouchIdleState = new CrouchIdleState(
                _crouchIdleStateConfig,
                _stateConfigCommon,
                _inputProvider
            );
            return crouchIdleState;
        }
        private CrouchWalkState BuildCrouchWalkState() {
            CrouchWalkState crouchWalkState = new CrouchWalkState(
                _crouchWalkStateConfig,
                _stateConfigCommon,
                _inputProvider,
                _cameraProvider
            );
            return crouchWalkState;
        }
        private OnePhaseLoopAnimationPlan BuildCrouchAnimation() {
            SpeedInjectableOPLAnimationPlayer opAnimationPlayer = new SpeedInjectableOPLAnimationPlayer(
                _animancer,
                _crouchAnimationConfig.CrouchAnimationMixer,
                _crouchLayerIndex,
                _crouchAnimationConfig.FadeTime,
                Easing.Function.CubicInOut
            );
            OnePhaseLoopAnimationPlan crouchAnimation = new OnePhaseLoopAnimationPlan(
                opAnimationPlayer
            );
            return crouchAnimation;
        }
    }
}