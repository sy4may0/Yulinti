using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class CrouchIdleState : IMoveState {
        private PlayerCrouchIdleStateConfig _crouchIdleStateConfig;
        private PlayerStateConfigCommon _stateConfigCommon;
        private MoveInputProvider _inputProvider;

        public int LayerIndex { get; } = 1;

        public CrouchIdleState(
            PlayerCrouchIdleStateConfig crouchIdleStateConfig,
            PlayerStateConfigCommon stateConfigCommon,
            MoveInputProvider inputProvider
        ) {
            _crouchIdleStateConfig = crouchIdleStateConfig;
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
                _crouchIdleStateConfig.AccelerationToTargetSpeed,
                _crouchIdleStateConfig.DecelerationToTargetSpeed,
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
                return StateID.CrouchWalk;
            }

            if (!_inputProvider.Crouch) {
                return StateID.Idle;
            }
            return StateID.None;
        }
    }
}