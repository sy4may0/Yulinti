using UnityEngine;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class CameraService {
        private readonly ICameraConfig _cameraConfig;

        public CameraService(ICameraConfig cameraConfig) {
            if (cameraConfig == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(CameraService)のCameraConfigがnullです。");
            }
            _cameraConfig = cameraConfig;
        }

        public Quaternion YawRotation
        {
            get
            {
                if (!_cameraConfig.Camera) return Quaternion.identity;
                var e = _cameraConfig.Camera.transform.eulerAngles;
                return Quaternion.Euler(0f, e.y, 0f);
            }
        }
        public Vector3 RightXZ   => (YawRotation * Vector3.right).normalized;
        public Vector3 ForwardXZ => (YawRotation * Vector3.forward).normalized;

        public void SetPosition(Vector3 position) {
            _cameraConfig.Camera.transform.position = position;
        }
        public void SetRotation(Quaternion rotation) {
            _cameraConfig.Camera.transform.rotation = rotation;
        }
    }
}