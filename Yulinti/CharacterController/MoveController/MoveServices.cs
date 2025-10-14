using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharacterController
{
    public struct MovePlan {
        public float PlannedHorizontalSpeed;
        public float PlannedYaw;
        public float PlannedVerticalSpeed;
    }

    public static class MoveMotionPlanner
    {
        /// 水平速度の計画（入力がなければ 0 / あれば desiredSpeed へ SmoothDamp）
        public float PlanHorizontalSpeed(
            Vector2 move,                  // 入力
            float desiredSpeed,            // 目標速度（歩き/走り）
            float currentSpeed,            // 現在の水平速度
            ref float speedVelRef,         // SmoothDamp 用参照
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

            return Mathf.SmoothDamp(currentSpeed, target, ref speedVelRef, smoothTime);
        }

        /// 垂直速度の計画（ジャンプ無し）
        public float PlanVerticalSpeed(
            bool isGrounded,               // 接地
            float currentVerticalSpeed,    // 現在の垂直速度（m/s）
            float gravityAccel,            // 重力加速度（負の値推奨）
            float deltaTime,               // 経過時間
            float groundedStickVel = -2f,  // 接地時に保つ下向き速度
            float maxFallSpeed = -50f      // 落下速度下限
        )
        {
            if (isGrounded)
            {
                // 地面に貼り付け（段差で浮かないように軽く押し付け）
                return groundedStickVel;
            }
            else
            {
                float v = currentVerticalSpeed + gravityAccel * deltaTime;
                return (v < maxFallSpeed) ? maxFallSpeed : v;
            }
        }

        /// カメラ基準の移動方向から目標ヨー角を計画
        public float PlanYawFollowCamera(
            CameraProvider cam,
            Vector2 move,
            float currentYawDeg,
            ref float yawVelRef,
            bool applySmoothDamp,
            float rotationSmoothTime,
            float inputDeadZoneSq = 1e-6f
        )
        {
            if (move.sqrMagnitude < inputDeadZoneSq)
                return currentYawDeg;

            Vector3 dir = cam.RightXZ * move.x + cam.ForwardXZ * move.y;
            if (dir.sqrMagnitude < 1e-8f) return currentYawDeg;

            dir.Normalize();
            float desiredYawDeg = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

            return PlanYaw(desiredYawDeg, currentYawDeg, ref yawVelRef, applySmoothDamp, rotationSmoothTime);
        }

        public float PlanYaw(
            float desiredYawDeg,
            float currentYawDeg,
            ref float yawVelRef,
            bool applySmoothDamp,
            float rotationSmoothTime
        )
        {
            if (!applySmoothDamp || rotationSmoothTime <= 0f)
                return desiredYawDeg;

            return Mathf.SmoothDampAngle(currentYawDeg, desiredYawDeg, ref yawVelRef, rotationSmoothTime);
        }
    }

    /// 反映系：必要な軸のみ適用
    public static class MoveApplier
    {
        /// 回転のみ適用
        public static void ApplyYaw(Transform transform, float yawDeg)
        {
            transform.rotation = Quaternion.Euler(0f, yawDeg, 0f);
        }

        /// 水平移動のみ適用（forward 方向へ）
        public static void ExecuteHorizontal(CharacterController controller, float horizontalSpeed, float deltaTime)
        {
            Vector3 move = controller.transform.forward * horizontalSpeed * deltaTime;
            controller.Move(move);
        }

        /// ★ 垂直移動のみ適用（ユーザー要望）
        public static void ExecuteVertical(CharacterController controller, float verticalSpeed, float deltaTime)
        {
            Vector3 move = Vector3.up * (verticalSpeed * deltaTime);
            controller.Move(move);
        }
    }
}
