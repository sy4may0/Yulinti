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
            Vector2 moveAction = context.MoveInput.action.ReadValue<Vector2>();
            return context.CharactorControlUtils.CalculateGeneralMoveOutput(
                moveAction, _baseSpeed, context.CurrentSpeed,
                _accelerationToTargetSpeed, _decelerationToTargetSpeed,
                context.MaxSmoothTime, context.MinSmoothTime,
                context.MoveInputDeadZoneSq,
                context.MainCamera, context.CurrentYaw, ref context.RotationVelRef,
                context.RotationSmoothTime
            );
        }
        public IMoveState TryTransition(MoveContext context) {
            Vector2 moveAction = context.MoveInput.action.ReadValue<Vector2>();
            bool sprintAction = context.SprintInput.action.ReadValue<bool>();

            if (moveAction.sqrMagnitude <= context.MoveInputDeadZoneSq) {
                return new IdleState();
            }
            // Sprintキーが押されたらRunStateに遷移
            if (sprintAction) {
                return new RunState();
            }

            return null;
        }

    }
}