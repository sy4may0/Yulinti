using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharactorControlUtils{
    public class CharactorControlUtils {
        /// <summary>
        /// 移動体の速度を計算する。現在の速度から目標速度に向かって加減速する。
        /// </summary>
        /// <param name="moveInput">移動入力(0.0~1.0) / InputSystemのVector2値</param>
        /// <param name="baseSpeed">ベーススピード（ステート側で補正済みの値）</param>
        /// <param name="currentSpeed">現在の速度</param>
        /// <param name="inputDeadZoneSq">入力デッドゾーンの二乗</param>
        /// <returns>目標速度</returns>
        public float CalculateSpeed(
            Vector2 moveInput, 
            float baseSpeed,
            float currentSpeed,
            float inputDeadZoneSq = 0.1f
        )
        {
            float mag = moveInput.sqrMagnitude;
            float targetSpeed = 0f;

            if (mag >= inputDeadZoneSq) {
                targetSpeed = baseSpeed;
            }

            return targetSpeed;
        }

        /// <summary>
        /// 速度のスムージング時間を計算する。
        /// </summary>
        /// <param name="targetSpeed">目標速度</param>
        /// <param name="currentSpeed">現在の速度</param>
        /// <param name="accelerationToTargetSpeed">目標速度ゲートまでの加速度(m/s^2イメージ)</param>
        /// <param name="decelerationToTargetSpeed">目標速度ゲートまでの減速度(m/s^2イメージ)</param>
        /// <param name="maxSmoothTime">最大スムージング時間</param>
        /// <param name="minSmoothTime">最小スムージング時間</param>
        /// <returns>速度のスムージング時間</returns>
        public float CalculateSpeedSmoothTime(
            float targetSpeed,
            float currentSpeed,
            float accelerationToTargetSpeed,
            float decelerationToTargetSpeed,
            float maxSmoothTime,
            float minSmoothTime
        )
        {
            float dv = Mathf.Abs(targetSpeed - currentSpeed);
            float aLimit = (targetSpeed > currentSpeed) 
                    ? accelerationToTargetSpeed 
                    : decelerationToTargetSpeed;

            float smoothTime = (dv > 1e-6f) 
                ? 2f * Mathf.Sqrt(dv / Mathf.Max(aLimit, 1e-6f))
                : minSmoothTime;
            
            smoothTime = Mathf.Clamp(smoothTime, minSmoothTime, maxSmoothTime);

            return smoothTime;
        }

        /// <summary>
        /// カメラ方向をベースとした移動体の回転を計算する。
        /// </summary>
        /// <param name="camera">カメラ</param>
        /// <param name="moveInput">移動入力(0.0~1.0) / InputSystemのVector2値</param>
        /// <param name="currentYaw">現在のYaw(回転対象の.eulerAngles.y)</param>
        /// <param name="rotationVelRef">SmoothDampAngleの参照用変数</param>
        /// <returns>Yaw回転(Quaternion)</returns>
        public Quaternion CalculateRotation(
            Camera camera, 
            Vector2 moveInput, 
            float currentYaw,
            ref float rotationVelRef,
            float rotationSmoothTime = 0.1f
        )
        {
            Transform cameraTransform = camera.transform;

            Quaternion yawOnly = cameraTransform
                ? Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0)
                : Quaternion.identity;

            Vector3 forward = yawOnly * Vector3.forward;
            Vector3 right = yawOnly * Vector3.right;

            Vector3 moveDirection = (right * moveInput.x + forward * moveInput.y);

            if (moveDirection.sqrMagnitude < 1e-6f)
            {
                return Quaternion.Euler(0, currentYaw, 0);
            }

            moveDirection.Normalize();

            float targetYaw = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float smoothYaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref rotationVelRef, rotationSmoothTime);

            return Quaternion.Euler(0, smoothYaw, 0);
        }

        /// <summary>
        /// 移動体の速度と回転を計算する。
        /// CalculateSpeed, CalculateRotation, CalculateSpeedSmoothTimeを使用して計算する。
        /// パラメータはCalculateSpeed, CalculateRotation, CalculateSpeedSmoothTimeのパラメータを参照。
        /// </summary>
        public MoveOutput CalculateGeneralMoveOutput(
            Vector2 moveInput,
            float baseSpeed,
            float currentSpeed,
            float accelerationToTargetSpeed,
            float decelerationToTargetSpeed,
            float maxSmoothTime,
            float minSmoothTime,
            float inputDeadZone,
            Camera camera,
            float currentYaw,
            ref float rotationVelRef,
            float rotationSmoothTime = 0.1f
        )
        {
            float desiredSpeed = CalculateSpeed(moveInput, baseSpeed, currentSpeed, inputDeadZone);
            Quaternion desiredDirection = CalculateRotation(camera, moveInput, currentYaw, ref rotationVelRef, rotationSmoothTime);
            float speedSmoothTime = CalculateSpeedSmoothTime(desiredSpeed, currentSpeed, accelerationToTargetSpeed, decelerationToTargetSpeed, maxSmoothTime, minSmoothTime);
            return new MoveOutput {
                DesiredSpeed = desiredSpeed,
                DesiredDirection = desiredDirection,
                SpeedSmoothTime = speedSmoothTime
            };
        }

    }

}