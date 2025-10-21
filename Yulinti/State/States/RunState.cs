using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class RunState : IMoveState {
        private MoveTuning _moveTuning;
        private RunStateConfig _runStateConfig;
        private InputProvider _inputProvider;
        private CameraProvider _cameraProvider;

        public int LayerIndex { get; } = 0;

        public RunState(
            MoveTuning moveTuning,
            RunStateConfig runStateConfig,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
        ) {
            _moveTuning = moveTuning;
            _runStateConfig = runStateConfig;
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
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
            YawPlan targetYaw = MovePlanner.PlanYawFollowCamera(
                _cameraProvider,
                _inputProvider.Move,
                payload.CurrentYaw,
                true,
                _moveTuning.RotationSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
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
            if (
                _inputProvider.Move.sqrMagnitude <= _moveTuning.MoveInputDeadZoneSq ||
                !_inputProvider.Sprint
            ) {
                return StateID.Walk;
            }

            return StateID.None;
        }
    }
}