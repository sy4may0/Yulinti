using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class IdleState : IMoveState {
        private MoveTuning _moveTuning;
        private IdleStateConfig _idleStateConfig;
        private InputProvider _inputProvider;
        private BaseStateLibrary _stateLibrary;

        public int LayerIndex { get; } = 0;

        public IdleState(
            MoveTuning moveTuning,
            IdleStateConfig idleStateConfig,
            InputProvider inputProvider,
            BaseStateLibrary stateLibrary
        ) {
            _moveTuning = moveTuning;
            _idleStateConfig = idleStateConfig;
            _inputProvider = inputProvider;
            _stateLibrary = stateLibrary;
        }

        public void Enter(MoveRuntime runtime) {}
        public void Exit(MoveRuntime runtime) {}
        public MovePlan Tick(MoveRuntime runtime, float deltaTime) {
            float targetSpeed = MoveMotionPlanner.PlanHorizontalSpeed(
                _inputProvider.Move,
                0f,
                runtime.CurrentSpeedHorizontal,
                ref runtime.SpeedVelRefHorizontal,
                true,
                _idleStateConfig.AccelerationToTargetSpeed,
                _idleStateConfig.DecelerationToTargetSpeed,
                _moveTuning.MinSmoothTime,
                _moveTuning.MaxSmoothTime,
                _moveTuning.MoveInputDeadZoneSq
            );
            float targetYaw = runtime.CurrentYaw;
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
            if (_inputProvider.Move.sqrMagnitude > _moveTuning.MoveInputDeadZoneSq) {
                return _stateLibrary.WalkState;
            }

            if (_inputProvider.Crouch) {
                return _stateLibrary.CrouchIdleState ?? null;
            }

            return null;
        }

        // Layer0ミキサーを使うステート。アニメーション遷移無し。
        public IAnimationPlan GetAnimationPlan() {
            return null;
        }
    }
}