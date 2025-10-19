using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
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