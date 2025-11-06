using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class IdleState : IMoveState {
        private PlayerIdleStateConfig _idleStateConfig;
        private PlayerStateConfigCommon _stateConfigCommon;
        private MoveInputProvider _inputProvider;

        public int LayerIndex { get; } = 0;

        public IdleState(
            PlayerIdleStateConfig idleStateConfig,
            PlayerStateConfigCommon stateConfigCommon,
            MoveInputProvider inputProvider
        ) {
            _idleStateConfig = idleStateConfig;
            _stateConfigCommon = stateConfigCommon;
            _inputProvider = inputProvider;
        }

        public void Enter(MoveRuntimeReadOnly moveRuntimeRO) {}
        public void Exit(MoveRuntimeReadOnly moveRuntimeRO) {}
        public MovePlan Tick(MoveRuntimeReadOnly moveRuntimeRO) {
            HorizontalSpeedPlan targetSpeed = MovePlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                0f,
                moveRuntimeRO.CurrentSpeedHorizontal,
                true,
                _idleStateConfig.AccelerationToTargetSpeed,
                _idleStateConfig.DecelerationToTargetSpeed,
                _stateConfigCommon.MinSmoothTime,
                _stateConfigCommon.MaxSmoothTime,
                _stateConfigCommon.MoveInputDeadZoneSq
            );
            YawPlan targetYaw = MovePlanner.PlanNoRotation(moveRuntimeRO.CurrentYaw);
            VerticalSpeedPlan targetVerticalSpeed = MovePlanner.PlanVerticalSpeed(
                moveRuntimeRO.IsGrounded,
                moveRuntimeRO.CurrentSpeedVertical,
                _stateConfigCommon.Gravity,
                moveRuntimeRO.DeltaTime
            );

            return new MovePlan(targetSpeed, targetYaw, targetVerticalSpeed);
        }
        public StateID TryTransition(MoveRuntimeReadOnly moveRuntimeRO) {
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