using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public static class MovePlanner {

        public struct HorizontalSpeedPlan {
            public float PlannedHorizontalSpeed;
            public float PlannedHorizontalSpeedSmoothTime;
        }

        public static float PlanHorizontalSpeed(
            Vector2 move,                  // 入力
            float desiredSpeed,            // 目標速度（歩き/走り）
            float currentSpeed,            // 現在の水平速度
            bool applySmoothDamp,          // スムージング有無
            float acceleration,            // 加速上限
            float deceleration,            // 減速上限
            float minSmoothTime,           // SmoothDamp 下限
            float maxSmoothTime,           // SmoothDamp 上限
            float inputDeadZoneSq          // 入力デッドゾーン（平方）
        )
        {
            float target = (move.sqrMagnitude >= inputDeadZoneSq) ? desiredSpeed : 0f;
            if (!applySmoothDamp) return target;
    
            float dv = Mathf.Abs(target - currentSpeed);
            float aLimit = (target > currentSpeed) ? Mathf.Max(acceleration, 1e-6f)
                                                   : Mathf.Max(deceleration, 1e-6f);
            float smoothTime = dv > 1e-6f ? 2f * Mathf.Sqrt(dv / aLimit) : minSmoothTime;
            smoothTime = Mathf.Clamp(smoothTime, minSmoothTime, maxSmoothTime);
    
            return new HorizontalSpeedPlan {
                PlannedHorizontalSpeed = target,
                PlannedHorizontalSpeedSmoothTime = smoothTime,
            };
        }

        public static VerticalSpeedPlan PlanVerticalSpeed(
            bool isGrounded,               // 接地
            float currentVerticalSpeed,    // 現在の垂直速度（m/s）
            float gravityAccel,            // 重力加速度（負の値推奨）
            float deltaTime,               // 経過時間
            float groundedStickVel = -0.1f,  // 接地時に保つ下向き速度
            float maxFallSpeed = -50f      // 落下速度下限
        )
        {
            if (isGrounded)
            {
                // TODO: 落下が気になるならSmoothTimeを設定する。

                // 地面に貼り付け（段差で浮かないように軽く押し付け）
                return new VerticalSpeedPlan {
                    TargetSpeed = groundedStickVel,
                    SmoothTime = 0f,
                };
            }
            else
            {
                float v = currentVerticalSpeed + gravityAccel * deltaTime;
                return new VerticalSpeedPlan {
                    TargetSpeed = (v < maxFallSpeed) ? maxFallSpeed : v,
                    SmoothTime = 0f,
                };
            }
        }

        public static YawPlan PlanYawFollowCamera(
            CameraProvider cam,
            Vector2 move,
            float currentYawDeg,
            bool applySmoothDamp,
            float rotationSmoothTime,
            float inputDeadZoneSq = 1e-6f
        )
        {
            if (move.sqrMagnitude < inputDeadZoneSq)
                return new YawPlan {
                    TargetYawDeg = currentYawDeg,
                    SmoothTime = 0f,
                };

            Vector3 dir = cam.RightXZ * move.x + cam.ForwardXZ * move.y;
            if (dir.sqrMagnitude < 1e-8f) return new YawPlan {
                TargetYawDeg = currentYawDeg,
                SmoothTime = 0f,
            };

            dir.Normalize();
            float desiredYawDeg = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

            return PlanYaw(desiredYawDeg, currentYawDeg, applySmoothDamp, rotationSmoothTime);
        }

        public static float PlanYaw(
            float desiredYawDeg,
            float currentYawDeg,
            bool applySmoothDamp,
            float rotationSmoothTime
        )
        {
            if (!applySmoothDamp || rotationSmoothTime <= 0f)
                return new YawPlan {
                    TargetYawDeg = desiredYawDeg,
                    SmoothTime = 0f,
                };

            return new YawPlan {
                TargetYawDeg = desiredYawDeg,
                SmoothTime = rotationSmoothTime,
            };
        }

        public static YawPlan PlanNoRotation(
            float currentYawDeg
        )
        {
            return new YawPlan {
                TargetYawDeg = currentYawDeg,
                SmoothTime = 0f,
            };
        }
    }
}