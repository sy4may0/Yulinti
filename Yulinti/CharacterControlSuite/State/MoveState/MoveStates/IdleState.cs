using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class IdleState : IMoveState {
        private IdleStateConfig _idleStateConfig;
        private StateConfigCommon _stateConfigCommon;
        private InputProvider _inputProvider;

        public int LayerIndex { get; } = 0;

        public IdleState(
            IdleStateConfig idleStateConfig,
            StateConfigCommon stateConfigCommon,
            InputProvider inputProvider,
        ) {
            _idleStateConfig = idleStateConfig;
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
                _idleStateConfig.AccelerationToTargetSpeed,
                _idleStateConfig.DecelerationToTargetSpeed,
                _stateConfigCommon.MinSmoothTime,
                _stateConfigCommon.MaxSmoothTime,
                _stateConfigCommon.MoveInputDeadZoneSq
            );
            YawPlan targetYaw = MovePlanner.PlanNoRotation(payload.CurrentYaw);
            VerticalSpeedPlan targetVerticalSpeed = MovePlanner.PlanVerticalSpeed(
                payload.IsGrounded,
                payload.CurrentSpeedVertical,
                _stateConfigCommon.Gravity,
                payload.DeltaTime
            );

            return new MovePlan {
                HorizontalSpeedPlan = targetSpeed,
                YawPlan = targetYaw,
                VerticalSpeedPlan = targetVerticalSpeed,
            };
        }
        public StateID TryTransition(StateRuntimePayload payload) {
            if (_inputProvider.Move.sqrMagnitude > _stateConfigCommon.MoveInputDeadZoneSq) {
                return StateID.Walk;
            }

            if (_inputProvider.Crouch) {
                return StateID.CrouchIdle;
            }

            return StateID.None;
        }
    }
}