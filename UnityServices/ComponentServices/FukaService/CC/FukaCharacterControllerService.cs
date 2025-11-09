using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ComponentServices.FukaService.CC.Internal;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaCharacterControllerService {
        private readonly CharacterController _characterController;

        private MoveInstruction _moveInstruction;

        private float _horizontalSpeedVelRef;
        private float _verticalSpeedVelRef;
        private float _yawVelRef;

        private float _currentSpeedHorizontal;
        private float _currentSpeedVertical;
        private float _currentYaw;

        public FukaCharacterControllerService(IFukaCharacterControllerConfig characterControllerConfig) {
            _characterController = characterControllerConfig.CharacterController;
            if (_characterController == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaCharacterControllerService)のCharacterControllerがnullです。");
            }
            _moveInstruction = new MoveInstruction();
            _horizontalSpeedVelRef = 0f;
            _verticalSpeedVelRef = 0f;
            _currentSpeedHorizontal = 0f;
            _currentSpeedVertical = 0f;
            _yawVelRef = 0f;
            _currentYaw = _characterController.transform.rotation.eulerAngles.y;
        }

        public float CurrentSpeedHorizontal => _currentSpeedHorizontal;
        public float CurrentSpeedVertical => _currentSpeedVertical;
        public float CurrentYaw => _currentYaw;
        public Vector3 CurrentPosition => _characterController.transform.position;
        public Quaternion CurrentRotation => _characterController.transform.rotation;

        private void ResetSpeeds() {
            _horizontalSpeedVelRef = 0f;
            _verticalSpeedVelRef = 0f;
            _currentSpeedHorizontal = 0f;
            _currentSpeedVertical = 0f;
        }

        private void ResetYaw() {
            _yawVelRef = 0f;
            _currentYaw = _characterController.transform.rotation.eulerAngles.y;
        }

        public void ForceSetPosition(Vector3 position) {
            _characterController.transform.position = position;
            ResetSpeeds();
        }

        public void ForceSetRotation(Quaternion rotation) {
            _characterController.transform.rotation = rotation;
            ResetYaw();
        }

        public void SmoothMoveHorizontalBySpeed(
            float targetSpeed,
            float smoothTime,
            float deltaTime
        ) {
            float speed = 0f;
            if (smoothTime <= 0.000001f) {
                speed = targetSpeed;
            } else {
                speed = Mathf.SmoothDamp(
                    _currentSpeedHorizontal,
                    targetSpeed,
                    ref _horizontalSpeedVelRef,
                    smoothTime,
                    Mathf.Infinity,
                    deltaTime
                );
            }

            Vector3 move = _characterController.transform.forward * speed * deltaTime;
            _moveInstruction.AddMove(move);
        }

        public void SmoothMoveVerticalBySpeed(
            float targetSpeed,
            float smoothTime,
            float deltaTime
        ) {
            float speed = 0f;
            if (smoothTime <= 0.000001f) {
                speed = targetSpeed;
            } else {
                speed = Mathf.SmoothDamp(
                    _currentSpeedVertical,
                    targetSpeed,
                    ref _verticalSpeedVelRef,
                    smoothTime,
                    Mathf.Infinity,
                    deltaTime
                );
            }

            Vector3 move = Vector3.up * speed * deltaTime;
            _moveInstruction.AddMove(move);
        }

        public void SmoothRotateByYaw(
            float targetYaw,
            float smoothTime,
            float deltaTime
        ) {
            float yaw = 0f;
            if (smoothTime <= 0.000001f) {
                yaw = targetYaw;
            } else {
                yaw = Mathf.SmoothDampAngle(
                    _currentYaw,
                    targetYaw,
                    ref _yawVelRef,
                    smoothTime,
                    Mathf.Infinity,
                    deltaTime
                );
            }

            _moveInstruction.AddYawDeg(Mathf.DeltaAngle(_currentYaw, yaw));
        }

        public void ApplyMove(float deltaTime) {
            Vector3 additionalMove = _moveInstruction.AdditionalMove;
            float additionalYawDeg = _moveInstruction.AdditionalYawDeg;

            _characterController.transform.rotation = Quaternion.Euler(0, _currentYaw + additionalYawDeg, 0);
            _characterController.Move(additionalMove);
            
            _currentYaw = _characterController.transform.rotation.eulerAngles.y;
            
            // 水平速度はXZ平面での移動距離をdeltaTimeで割る
            Vector3 horizontalMove = new Vector3(additionalMove.x, 0, additionalMove.z);
            _currentSpeedHorizontal = horizontalMove.magnitude / deltaTime;
            _currentSpeedVertical = additionalMove.y / deltaTime;
            
            _moveInstruction.Reset();
        }
    }
}