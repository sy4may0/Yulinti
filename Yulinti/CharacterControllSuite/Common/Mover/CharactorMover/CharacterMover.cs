using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class CharacterMover {
        private readonly CharacterController _characterController;

        public CharacterMover(CharacterController characterController) {
            if (characterController == null) {
                Debug.LogError("CharacterController is null");
                return;
            }
            _characterController = characterController;
        }

        public void ApplyMove(
            MovePlan movePlan,
            MoveRuntimeCommands moveRuntimeWO,
            MoveRuntimeReadOnly moveRuntimeRO
        ) {
            float currentYaw = ApplyYaw(
                movePlan.YawPlan,
                moveRuntimeRO
            );
 
            float currentSpeedHorizontal = ApplyHorizontalMove(
                movePlan.HorizontalSpeedPlan,
                moveRuntimeRO
            );

            float currentSpeedVertical = ApplyVerticalMove(
                movePlan.VerticalSpeedPlan,
                moveRuntimeRO
            );

            moveRuntimeWO.PostMove(new MoveResult(currentSpeedHorizontal, currentSpeedVertical, currentYaw));
       }

        private float ApplyYaw(YawPlan yawPlan, MoveRuntime moveRuntime) {
            float yaw = Mathf.SmoothDampAngle(
                moveRuntime.CurrentYaw,
                yawPlan.TargetYawDeg,
                ref moveRuntime.YawVelRef,
                yawPlan.SmoothTime,
                Mathf.Infinity,
                moveRuntime.DeltaTime
            );
            if (_characterController.transform != null) {
                _characterController.transform.rotation = Quaternion.Euler(0, yaw, 0);
            }

            return yaw;
        }

        private float ApplyHorizontalMove(HorizontalSpeedPlan horizontalSpeedPlan, MoveRuntimeReadOnly moveRuntimeRO) {
            float horizontalSpeed = Mathf.SmoothDamp(
                moveRuntimeRO.CurrentSpeedHorizontal,
                horizontalSpeedPlan.TargetSpeed,
                ref moveRuntimeRO.SpeedVelRefHorizontal,
                horizontalSpeedPlan.SmoothTime,
                Mathf.Infinity,
                moveRuntimeRO.DeltaTime
            );

            if (_characterController != null) {
                Vector3 move = _characterController.transform.forward * horizontalSpeed * moveRuntimeRO.DeltaTime;
                _characterController.Move(move);
            }

            return horizontalSpeed;
        }

        private float ApplyVerticalMove(VerticalSpeedPlan verticalSpeedPlan, MoveRuntimeReadOnly moveRuntimeRO) {
            float verticalSpeed = 0f;
            if (verticalSpeedPlan.SmoothTime != 0f) {
                verticalSpeed = Mathf.SmoothDamp(
                    moveRuntimeRO.CurrentSpeedVertical,
                    verticalSpeedPlan.TargetSpeed,
                    ref moveRuntimeRO.SpeedVelRefVertical,
                    verticalSpeedPlan.SmoothTime,
                    Mathf.Infinity,
                    moveRuntimeRO.DeltaTime
                );
            } else {
                verticalSpeed = verticalSpeedPlan.TargetSpeed;
            }

            if (_characterController != null) {
                Vector3 move = Vector3.up * verticalSpeed * moveRuntimeRO.DeltaTime;
                _characterController.Move(move);
            }

            return verticalSpeed;
        }
    }
}