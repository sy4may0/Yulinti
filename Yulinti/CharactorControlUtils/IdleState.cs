using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharactorControlUtils {
    [System.Serializable]
    public class IdleState : IMoveState {
        public void Enter(MoveContext context) {}
        public void Exit(MoveContext context) {}
        public MoveOutput Tick(MoveContext context, float deltaTime) {
            Quaternion desiredDirection = Quaternion.identity;
            return new MoveOutput {
                DesiredSpeed = 0f,
                DesiredDirection = desiredDirection,
                SpeedSmoothTime = 0f
            };
        }

        public IMoveState TryTransition(MoveContext context) {
            Vector2 moveAction = context.MoveInput.action.ReadValue<Vector2>();
            if (moveAction.sqrMagnitude > context.MoveInputDeadZoneSq) {
                return new WalkState();
            }
            return null;
        }
    }
}