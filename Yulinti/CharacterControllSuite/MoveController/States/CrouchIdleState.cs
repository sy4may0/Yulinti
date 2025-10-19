using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class CrouchIdleState : IMoveState {
        private MoveTuning _moveTuning;
        private CrouchIdleStateConfig _crouchIdleStateConfig;
        private InputProvider _inputProvider;
        private BaseStateLibrary _stateLibrary;
        private ThreePhaseAnimationPlan _crouchAnimationPlan;

        public int LayerIndex { get; } = 1;

        public CrouchIdleState(
            MoveTuning moveTuning,
            CrouchIdleStateConfig crouchIdleStateConfig,
            InputProvider inputProvider,
            BaseStateLibrary stateLibrary,
            ThreePhaseAnimationPlan crouchAnimationPlan
        ) {
            _moveTuning = moveTuning;
            _crouchIdleStateConfig = crouchIdleStateConfig;
            _inputProvider = inputProvider;
            _stateLibrary = stateLibrary;
            _crouchAnimationPlan = crouchAnimationPlan;
        }

        public void Enter(MoveRuntime runtime) {}
        public void Exit(MoveRuntime runtime) {}
        public MovePlan Tick(MoveRuntime runtime, float deltaTime) {
            float targetSpeed = MoveMotionPlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                0f,
                runtime.CurrentSpeedHorizontal,
                ref runtime.SpeedVelRefHorizontal,
                true,
                _crouchIdleStateConfig.AccelerationToTargetSpeed,
                _crouchIdleStateConfig.DecelerationToTargetSpeed,
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
            float targetYaw = runtime.CurrentYaw;
            float targetVerticalSpeed = MoveMotionPlanner.PlanVerticalSpeed(
                runtime.IsGrounded,
                runtime.CurrentSpeedVertical,
                _moveTuning.Gravity,
                deltaTime
            );

            return new MovePlan {
                PlannedHorizontalSpeed = targetSpeed,
                PlannedYaw = targetYaw,
                PlannedVerticalSpeed = targetVerticalSpeed,
            };
        }

        public IMoveState TryTransition(MoveRuntime runtime) {
            if (_inputProvider.Move.sqrMagnitude > _moveTuning.MoveInputDeadZoneSq) {
                return _stateLibrary.WalkState;
            }

            if (!_inputProvider.Crouch) {
                return _stateLibrary.IdleState;
            }
            return null;
        }

        public IAnimationPlan GetAnimationPlan() {
            return _crouchAnimationPlan;
        }
    }
}