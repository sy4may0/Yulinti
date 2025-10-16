using UnityEngine;

namespace Yulinti.CharacterController {
    public sealed class RunState : IMoveState {
        private MoveTuning _moveTuning;
        private RunStateConfig _runStateConfig;
        private InputProvider _inputProvider;
        private CameraProvider _cameraProvider;

        public readonly int LayerIndex = 0;

        public RunState(
            MoveTuning moveTuning,
            RunStateConfig runStateConfig,
            InputProvider inputProvider,
            CameraProvider cameraProvider
        ) {
            _moveTuning = moveTuning;
            _runStateConfig = runStateConfig;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
        }

        public void Enter(MoveRuntime runtime) {}
        public void Exit(MoveRuntime runtime) {}
        public MovePlan Tick(MoveRuntime runtime, float deltaTime) {
            float targetSpeed = MoveMotionPlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                _runStateConfig.BaseSpeed,
                runtime.CurrentSpeedHorizontal,
                ref runtime.SpeedVelRefHorizontal,
                true,
                _runStateConfig.AccelerationToTargetSpeed,
                _runStateConfig.DecelerationToTargetSpeed,
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq,
            );
            float targetYaw = MoveMotionPlanner.PlanYawFollowCamera(
                _cameraProvider,
                _inputProvider.Move,
                runtime.CurrentYaw,
                ref runtime.YawVelRef,
                true,
                _moveTuning.RotationSmoothTime,
                _moveTuning.MoveInputDeadZoneSq,
            );
            float targetVerticalSpeed = MoveMotionPlanner.PlanVerticalSpeed(
                runtime.IsGrounded,
                runtime.CurrentSpeedVertical,
                _moveTuning.Gravity,
                deltaTime,
            );

            return new MovePlan {
                PlannedHorizontalSpeed = targetSpeed,
                PlannedYaw = targetYaw,
                PlannedVerticalSpeed = targetVerticalSpeed,
            };
        }
        public IMoveState TryTransition(MoveRuntime runtime) {
            if (
                _inputProvider.Move.sqrMagnitude <= _moveTuning.MoveInputDeadZoneSq ||
                !_inputProvider.Sprint
            ) {
                return runtime.WalkState;
            }

            return null;
        }
        // Layer0ミキサーを使うステート。アニメーション遷移無し。
        public IAnimationPlan GetAnimationPlan() {
            return null;
        }
    }
}