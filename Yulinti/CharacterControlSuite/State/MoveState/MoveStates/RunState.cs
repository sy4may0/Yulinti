using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class RunState : IMoveState {
        private RunStateConfig _runStateConfig;
        private StateConfigCommon _stateConfigCommon;
        private InputProvider _inputProvider;
        private CameraProvider _cameraProvider;

        public int LayerIndex { get; } = 0;

        public RunState(
            RunStateConfig runStateConfig,
            StateConfigCommon stateConfigCommon,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
        ) {
            _runStateConfig = runStateConfig;
            _stateConfigCommon = stateConfigCommon;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
        }

        public void Enter(StateRuntimePayload payload) {}
        public void Exit(StateRuntimePayload payload) {}
        public MovePlan Tick(StateRuntimePayload payload) {
            HorizontalSpeedPlan targetSpeed = MovePlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                _runStateConfig.BaseSpeed,
                payload.CurrentSpeedHorizontal,
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
                payload.CurrentYaw,
                true,
                _stateConfigCommon.RotationSmoothTime,
                _stateConfigCommon.MoveInputDeadZoneSq
            );
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