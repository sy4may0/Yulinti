using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class RunState : IMoveState {
        private PlayerRunStateConfig _runStateConfig;
        private PlayerStateConfigCommon _stateConfigCommon;
        private MoveInputProvider _inputProvider;
        private CameraProvider _cameraProvider;

        public int LayerIndex { get; } = 0;

        public RunState(
            PlayerRunStateConfig runStateConfig,
            PlayerStateConfigCommon stateConfigCommon,
            MoveInputProvider inputProvider,
            CameraProvider cameraProvider
        ) {
            _runStateConfig = runStateConfig;
            _stateConfigCommon = stateConfigCommon;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
        }

        public void Enter(MoveRuntimeReadOnly moveRuntimeRO) {}
        public void Exit(MoveRuntimeReadOnly moveRuntimeRO) {}
        public MovePlan Tick(MoveRuntimeReadOnly moveRuntimeRO) {
            HorizontalSpeedPlan targetSpeed = MovePlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                _runStateConfig.BaseSpeed,
                moveRuntimeRO.CurrentSpeedHorizontal,
                true,
                _runStateConfig.AccelerationToTargetSpeed,
                _runStateConfig.DecelerationToTargetSpeed,
                _stateConfigCommon.MinSmoothTime,
                _stateConfigCommon.MaxSmoothTime,
                _stateConfigCommon.MoveInputDeadZoneSq
            );
            YawPlan targetYaw = MovePlanner.PlanYawFollowCamera(
                _cameraProvider,
                _inputProvider.Move,
                moveRuntimeRO.CurrentYaw,
                true,
                _stateConfigCommon.RotationSmoothTime,
                _stateConfigCommon.MoveInputDeadZoneSq
            );
            VerticalSpeedPlan targetVerticalSpeed = MovePlanner.PlanVerticalSpeed(
                moveRuntimeRO.IsGrounded,
                moveRuntimeRO.CurrentSpeedVertical,
                _stateConfigCommon.Gravity,
                moveRuntimeRO.DeltaTime
            );

            return new MovePlan(targetSpeed, targetYaw, targetVerticalSpeed);
        }
        public StateID TryTransition(MoveRuntimeReadOnly moveRuntimeRO) {
            if (
                _inputProvider.Move.sqrMagnitude <= _stateConfigCommon.MoveInputDeadZoneSq ||
                !_inputProvider.Sprint
            ) {
                return StateID.Walk;
            }

            return StateID.None;
        }
    }
}