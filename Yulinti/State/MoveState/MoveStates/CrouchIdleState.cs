using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class CrouchIdleState : IMoveState {
        private MoveTuning _moveTuning;
        private CrouchIdleStateConfig _crouchIdleStateConfig;
        private InputProvider _inputProvider;

        public int LayerIndex { get; } = 1;

        public CrouchIdleState(
            MoveTuning moveTuning,
            CrouchIdleStateConfig crouchIdleStateConfig,
            InputProvider inputProvider,
        ) {
            _moveTuning = moveTuning;
            _crouchIdleStateConfig = crouchIdleStateConfig;
            _inputProvider = inputProvider;
        }

        public void Enter(StateRuntimePayload payload) {}
        public void Exit(StateRuntimePayload payload) {}
        public MovePlan Tick(StateRuntimePayload payload) {
            HorizontalSpeedPlan targetSpeed = MovePlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                0f,
                payload.CurrentSpeedHorizontal,
                true,
                _crouchIdleStateConfig.AccelerationToTargetSpeed,
                _crouchIdleStateConfig.DecelerationToTargetSpeed,
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
            YawPlan targetYaw = MovePlanner.PlanNoRotation(payload.CurrentYaw);
            VerticalSpeedPlan targetVerticalSpeed = MovePlanner.PlanVerticalSpeed(
                payload.IsGrounded,
                payload.CurrentSpeedVertical,
                _moveTuning.Gravity,
                payload.DeltaTime
            );

            return new MovePlan {
                HorizontalSpeedPlan = targetSpeed,
                YawPlan = targetYaw,
                VerticalSpeedPlan = targetVerticalSpeed,
            };
        }

        public StateID TryTransition(StateRuntimePayload payload) {
            if (_inputProvider.Move.sqrMagnitude > _moveTuning.MoveInputDeadZoneSq) {
                return StateID.CrouchWalk;
            }

            if (!_inputProvider.Crouch) {
                return StateID.Idle;
            }
            return StateID.None;
        }
    }
}