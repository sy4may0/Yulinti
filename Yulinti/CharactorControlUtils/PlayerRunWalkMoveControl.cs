using UnityEngine;

namespace Yulinti.CharactorControlUtils
{
    /// <summary>
    /// プレイヤーの走行/歩行の移動制御
    /// </summary>
    [System.Serializable]
    public class PlayerRunWalkMoveControl
    {
        [Header("移動制御")]
        [Tooltip("走行スピード")]
        [SerializeField] private float _runSpeed = 1.5f;

        [Tooltip("歩行スピード")]
        [SerializeField] private float _walkSpeed = 1.0f;

        [Tooltip("目標速度ゲートまでの加速度(m/s^2イメージ)")]
        [SerializeField] private float _accelerationToTargetSpeed = 10f;

        [Tooltip("目標速度ゲートまでの減速度(m/s^2イメージ)")]
        [SerializeField] private float _decelerationToTargetSpeed = 14f;

        [Tooltip("入力デッドゾーン")]
        [SerializeField] private float _inputDeadZone = 0.1f;

        [Tooltip("最大スムージング時間")]
        [SerializeField] private float _maxSmoothTime = 0.80f;

        [Tooltip("最小スムージング時間")]
        [SerializeField] private float _minSmoothTime = 0.01f;

        [Header("回転制御")]
        [Tooltip("回転のスムージング値")]
        [SerializeField] private float _rotationSmoothTime = 0.1f;


        // SmoothDampの参照用変数
        private float _speedVelocity = 0f;

        // SmoothDampAngleの参照用変数
        private float _turnVelocity = 0f;

        /// <summary>
        /// 移動体の速度を計算する。現在の速度から目標速度に向かって加減速する。
        /// </summary>
        /// <param name="moveInput">移動入力(0.0~1.0) / InputSystemのVector2値</param>
        /// <param name="sprintInput">スプリント入力(true:スプリント, false:歩行) / InputSystemのBool値</param>
        /// <param name="currentSpeed">現在の速度</param>
        /// <returns>速度</returns>
        public float CalculateSpeed(Vector2 moveInput, bool sprintInput, float currentSpeed)
        {
            float mag = moveInput.magnitude;
            float targetSpeed = 0f;

            if (mag >= _inputDeadZone) {
                targetSpeed = sprintInput ? _runSpeed : _walkSpeed;
                // 歩きの場合アナログ入力によって速度を調整
                if (!sprintInput) targetSpeed *= mag;
            }

            float dv = Mathf.Abs(targetSpeed - currentSpeed);
            float aLimit = (targetSpeed > currentSpeed) 
                    ? _accelerationToTargetSpeed 
                    : _decelerationToTargetSpeed;

            float smoothTime = (dv > 1e-6f) 
                ? 2f * Mathf.Sqrt(dv / Mathf.Max(aLimit, 1e-6f))
                : _minSmoothTime;

            smoothTime = Mathf.Clamp(smoothTime, _minSmoothTime, _maxSmoothTime);

            return Mathf.SmoothDamp(currentSpeed, targetSpeed, ref _speedVelocity, smoothTime);
        }

        /// <summary>
        /// カメラ方向をベースとした移動体の回転を計算する。
        /// </summary>
        /// <param name="camera">カメラ</param>
        /// <param name="moveInput">移動入力(0.0~1.0) / InputSystemのVector2値</param>
        /// <param name="currentYaw">現在のYaw(回転対象の.eulerAngles.y)</param>
        /// <returns>Yaw回転(Quaternion)</returns>
        public Quaternion CalculateRotation(Camera camera, Vector2 moveInput, float currentYaw)
        {
            Transform cameraTransform = camera.transform;

            Quaternion yawOnly = cameraTransform
                ? Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0)
                : Quaternion.identity;

            Vector3 forward = yawOnly * Vector3.forward;
            Vector3 right = yawOnly * Vector3.right;

            Vector3 moveDirection = (right * moveInput.x + forward * moveInput.y);

            if (moveDirection.magnitude < 1e-6f)
            {
                return Quaternion.Euler(0, currentYaw, 0);
            }

            moveDirection.Normalize();

            float targetYaw = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float yaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref _turnVelocity, _rotationSmoothTime);

            return Quaternion.Euler(0, yaw, 0);
        }
    }
}