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
    }

    [System.Serializable]
    public class CharacterMover {
        [Header("CharacterMover/CharacterMover設定")]
        [Tooltip("CharacterControllerコンポーネント")]
        [SerializeField] private CharacterController _characterController;

        public void ApplyMove(MovePlan movePlan, MoveRuntime moveRuntime, float deltaTime) {
            ApplyYaw(
                movePlan.YawPlan,
                moveRuntime
            );
 
            ApplyHorizontalMove(
                movePlan.HorizontalSpeedPlan,
                moveRuntime,
                deltaTime
            );

            ApplyVerticalMove(
                movePlan.VerticalSpeedPlan,
                moveRuntime,
                deltaTime
            );
       }

        private void ApplyYaw(YawPlan yawPlan, MoveRuntime moveRuntime) {
            float yaw = Mathf.SmoothDampAngle(
                moveRuntime.CurrentYaw,
                yawPlan.TargetYawDeg,
                ref moveRuntime.YawVelRef,
                yawPlan.SmoothTime
            );
            if (_characterController.transform != null) {
                _characterController.transform.rotation = Quaternion.Euler(0, yaw, 0);
            }
        }

        private void ApplyHorizontalMove(HorizontalSpeedPlan horizontalSpeedPlan, MoveRuntime moveRuntime, float deltaTime) {
            float horizontalSpeed = Mathf.SmoothDamp(
                moveRuntime.CurrentSpeedHorizontal,
                horizontalSpeedPlan.TargetSpeed,
                ref moveRuntime.SpeedVelRefHorizontal,
                horizontalSpeedPlan.SmoothTime
            );

            if (_characterController != null) {
                Vector3 move = _characterController.transform.forward * horizontalSpeed * deltaTime;
                _characterController.Move(move);
            }
        }

        private void ApplyVerticalMove(VerticalSpeedPlan verticalSpeedPlan, MoveRuntime moveRuntime, float deltaTime) {
            float verticalSpeed = Mathf.SmoothDamp(
                moveRuntime.CurrentSpeedVertical,
                verticalSpeedPlan.TargetSpeed,
                ref moveRuntime.SpeedVelRefVertical,
                verticalSpeedPlan.SmoothTime
            );

            if (_characterController != null) {
                Vector3 move = Vector3.up * verticalSpeed * deltaTime;
                _characterController.Move(move);
            }
        }


    }
}