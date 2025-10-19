using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class CrouchWalkState : IMoveState {
        private MoveTuning _moveTuning;
        private CrouchWalkStateConfig _crouchWalkStateConfig;
        private InputProvider _inputProvider;
        private CameraProvider _cameraProvider;
        private BaseStateLibrary _stateLibrary;
        private ThreePhaseAnimationPlan _crouchAnimationPlan;

        public int LayerIndex { get; } = 1;

        public CrouchWalkState(
            MoveTuning moveTuning,
            CrouchWalkStateConfig crouchWalkStateConfig,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
            BaseStateLibrary stateLibrary,
            ThreePhaseAnimationPlan crouchAnimationPlan
        ) {
            _moveTuning = moveTuning;
            _crouchWalkStateConfig = crouchWalkStateConfig;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
            _stateLibrary = stateLibrary;
            _crouchAnimationPlan = crouchAnimationPlan;
        }

        public void Enter(MoveRuntime runtime) {}
        public void Exit(MoveRuntime runtime) {}
        public MovePlan Tick(MoveRuntime runtime, float deltaTime) {
            float targetSpeed = MoveMotionPlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                _crouchWalkStateConfig.BaseSpeed,
                runtime.CurrentSpeedHorizontal,
                ref runtime.SpeedVelRefHorizontal,
                true,
                _crouchWalkStateConfig.AccelerationToTargetSpeed,
                _crouchWalkStateConfig.DecelerationToTargetSpeed,
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
            float targetYaw = MoveMotionPlanner.PlanYawFollowCamera(
                _cameraProvider,
                _inputProvider.Move,
                runtime.CurrentYaw,
                ref runtime.YawVelRef,
                true,
                _moveTuning.RotationSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
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
            if (_inputProvider.Move.sqrMagnitude <= _moveTuning.MoveInputDeadZoneSq) {
                return _stateLibrary.CrouchIdleState;
            }

            if (!_inputProvider.Crouch) {
                return _stateLibrary.IdleState;
            }

            return null;
        }
        // Layer0ミキサーを使うステート。アニメーション遷移無し。
        public IAnimationPlan GetAnimationPlan() {
            return _crouchAnimationPlan;
        }
    }
}