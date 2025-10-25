using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {

    public struct MoveResult {
        public readonly float CurrentSpeedHorizontal;
        public readonly float CurrentSpeedVertical;
        public readonly float CurrentYaw;

        public MoveResult(float currentSpeedHorizontal, float currentSpeedVertical, float currentYaw) {
            CurrentSpeedHorizontal = currentSpeedHorizontal;
            CurrentSpeedVertical = currentSpeedVertical;
            CurrentYaw = currentYaw;
        }
    }

    public class MoveRuntime {
        public float CurrentSpeedHorizontal;
        public float SpeedVelRefHorizontal;
        public float CurrentYaw;
        public float YawVelRef;
        public float CurrentSpeedVertical;
        public float SpeedVelRefVertical;
        public float DeltaTime;
        public bool IsGrounded;

        public MoveRuntime(
            float deltaTime,
            float currentSpeedHorizontal,
            float currentSpeedVertical,
            float currentYaw,
            bool isGrounded
        ) {
            DeltaTime = deltaTime;
            CurrentSpeedHorizontal = currentSpeedHorizontal;
            CurrentSpeedVertical = currentSpeedVertical;
            CurrentYaw = currentYaw;
            IsGrounded = isGrounded;
            SpeedVelRefHorizontal = 0f;
            SpeedVelRefVertical = 0f;
            YawVelRef = 0f;
        }

        public StateRuntimePayload BuildStateRuntimePayload() {
            return new StateRuntimePayload(
                DeltaTime,
                CurrentSpeedHorizontal,
                CurrentSpeedVertical,
                CurrentYaw,
                IsGrounded
            );
        }

        public void PostMove(
            MoveResult moveResult
        ) {
            CurrentSpeedHorizontal = moveResult.CurrentSpeedHorizontal;
            CurrentSpeedVertical = moveResult.CurrentSpeedVertical;
            CurrentYaw = moveResult.CurrentYaw;
        }
    }

    [System.Serializable]
    public class CharacterMover {
        [Header("CharacterMover/CharacterMover設定")]
        [Tooltip("CharacterControllerコンポーネント")]
        [SerializeField] private CharacterController _characterController;

        public void ApplyMove(MovePlan movePlan, MoveRuntime moveRuntime) {
            float currentYaw = ApplyYaw(
                movePlan.YawPlan,
                moveRuntime
            );
 
            float currentSpeedHorizontal = ApplyHorizontalMove(
                movePlan.HorizontalSpeedPlan,
                moveRuntime,
                moveRuntime.DeltaTime
            );

            float currentSpeedVertical = ApplyVerticalMove(
                movePlan.VerticalSpeedPlan,
                moveRuntime,
                moveRuntime.DeltaTime
            );

            moveRuntime.PostMove(new MoveResult(currentSpeedHorizontal, currentSpeedVertical, currentYaw));
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

        private float ApplyHorizontalMove(HorizontalSpeedPlan horizontalSpeedPlan, MoveRuntime moveRuntime, float deltaTime) {
            float horizontalSpeed = Mathf.SmoothDamp(
                moveRuntime.CurrentSpeedHorizontal,
                horizontalSpeedPlan.TargetSpeed,
                ref moveRuntime.SpeedVelRefHorizontal,
                horizontalSpeedPlan.SmoothTime,
                Mathf.Infinity,
                moveRuntime.DeltaTime
            );

            if (_characterController != null) {
                Vector3 move = _characterController.transform.forward * horizontalSpeed * deltaTime;
                _characterController.Move(move);
            }

            return horizontalSpeed;
        }

        private float ApplyVerticalMove(VerticalSpeedPlan verticalSpeedPlan, MoveRuntime moveRuntime, float deltaTime) {
            float verticalSpeed = 0f;
            if (verticalSpeedPlan.SmoothTime != 0f) {
                verticalSpeed = Mathf.SmoothDamp(
                    moveRuntime.CurrentSpeedVertical,
                    verticalSpeedPlan.TargetSpeed,
                    ref moveRuntime.SpeedVelRefVertical,
                    verticalSpeedPlan.SmoothTime,
                    Mathf.Infinity,
                    moveRuntime.DeltaTime
                );
            } else {
                verticalSpeed = verticalSpeedPlan.TargetSpeed;
            }

            if (_characterController != null) {
                Vector3 move = Vector3.up * verticalSpeed * deltaTime;
                _characterController.Move(move);
            }

            return verticalSpeed;
        }
    }
}