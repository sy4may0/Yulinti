using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharacterController {
    public class MoveRuntime {
        public float CurrentSpeedHorizontal;
        public float SpeedVelRefHorizontal;
        public float CurrentYaw;
        public float YawVelRef;
        public float CurrentSpeedVertical;
        public float SpeedVelRefVertical;
        public bool IsGrounded;
        public IMoveState CurrentState;
    }
}