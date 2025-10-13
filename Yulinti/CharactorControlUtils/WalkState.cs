using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharactorControlUtils {
    [System.Serializable]
    public class WalkState : IMoveState {
        [Header("WalkState移動制御")]
        [SerializeField] private float _baseSpeed = 1.0f;
        [SerializeField] private float _accelerationToTargetSpeed = 10f;
        [SerializeField] private float _decelerationToTargetSpeed = 14f;

        public void Enter(MoveContext context) {}
        public void Exit(MoveContext context) {}
        public MoveOutput Tick(MoveContext context, float deltaTime) {
            Vector2 moveInput = context.Config.MoveInput.action.ReadValue<Vector2>();
            return context.CharactorControlUtils.CalculateGeneralMoveOutput(
                moveInput, _baseSpeed, context.CurrentSpeed,
                _accelerationToTargetSpeed, _decelerationToTargetSpeed,
                context.MaxSmoothTime, context.MinSmoothTime,
                context.Config.MoveInputDeadZone,
                context.MainCamera, context.CurrentYaw, ref context.RotationVelRef,
                context.RotationSmoothTime
            );
        }
        public IMoveState TryTransition(MoveContext context) {
            var moveAction = context?.Config?.MoveInput?.action;
            var sprintAction = context?.Config?.SprintInput?.action;

            if (moveAction == null) return null;
            // 入力が0になったらIdleStateに遷移
            if (moveAction.ReadValue<Vector2>().sqrMagnitude <= context.MoveInputDeadZoneSq) {
                return new IdleState();
            }
            // Sprintキーが押されたらRunStateに遷移
            if (sprintAction != null && sprintAction.ReadValue<bool>()) {
                return new RunState();
            }

            return null;
        }

    }
}