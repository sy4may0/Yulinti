using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharactorControlUtils {
    [System.Serializable]
    public class RunState : IMoveState {
        [Header("RunState移動制御")]
        [SerializeField] private float _baseSpeed = 1.5f;
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
                context.Config.Camera, context.CurrentYaw, ref context.RotationVelRef,
                context.RotationSmoothTime
            );
        }
        public IMoveState TryTransition(MoveContext context) {
            var moveAction = context?.Config?.MoveInput?.action;
            var sprintAction = context?.Config?.SprintInput?.action;

            if (moveAction == null || sprintAction == null) return null;

            if (
                moveAction.ReadValue<Vector2>().sqrMagnitude <= context.MoveInputDeadZoneSq ||
                !sprintAction.ReadValue<bool>()
            ) {
                return new WalkState();
            }

            return null;
        }
    }
}