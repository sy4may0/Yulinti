using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class WalkState : IMoveState {
        private MoveTuning _moveTuning;
        private WalkStateConfig _walkStateConfig;
        private InputProvider _inputProvider;
        private CameraProvider _cameraProvider;

        public int LayerIndex { get; } = 0;

        public WalkState(
            MoveTuning moveTuning,
            WalkStateConfig walkStateConfig,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
        ) {
            _moveTuning = moveTuning;
            _walkStateConfig = walkStateConfig;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
        }

        public void Enter(StateRuntimePayload payload) {}
        public void Exit(StateRuntimePayload payload) {}
        public MovePlan Tick(StateRuntimePayload payload) {
            HorizontalSpeedPlan targetSpeed = MovePlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                _walkStateConfig.BaseSpeed,
                payload.CurrentSpeedHorizontal,
                true,
                _walkStateConfig.AccelerationToTargetSpeed,
                _walkStateConfig.DecelerationToTargetSpeed,
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
            if (_inputProvider.Move.sqrMagnitude <= _moveTuning.MoveInputDeadZoneSq) {
                return StateID.Idle;
            }
            if (_inputProvider.Sprint) {
                return StateID.Run;
            }
            if (_inputProvider.Crouch) {
                return StateID.CrouchWalk;
            }

            return StateID.None;
        }
    }
}