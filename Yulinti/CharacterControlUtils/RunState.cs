using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.CharacterControlUtils;

namespace Yulinti.CharacterControlUtils {
    [System.Serializable]
    public class RunState : IMoveState {
        [Header("RunState移動制御")]
        [SerializeField] private float _baseSpeed = 1.5f;
        [SerializeField] private float _accelerationToTargetSpeed = 10f;
        [SerializeField] private float _decelerationToTargetSpeed = 14f;

        public void Enter(MoveContext context) {}
        public void Exit(MoveContext context) {}
        public MoveOutput Tick(MoveContext context, float deltaTime) {
            return context.CharacterControlUtil.CalculateGeneralMoveOutput(
                context.MoveAction, _baseSpeed, context.CurrentSpeed,
                _accelerationToTargetSpeed, _decelerationToTargetSpeed,
                context.MaxSmoothTime, context.MinSmoothTime,
                context.MoveInputDeadZoneSq,
                context.MainCamera, context.CurrentYaw, ref context.RotationVelRef,
                context.RotationSmoothTime
            );
        }
        public IMoveState TryTransition(MoveContext context) {
            if (
                context.MoveAction.sqrMagnitude <= context.MoveInputDeadZoneSq ||
                !context.SprintAction
            ) {
                return context.WalkState;
            }

            return null;
        }
    }
}