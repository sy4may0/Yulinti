using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.CharacterControllSuite;

namespace Yulinti.ServiceSuite
{
    public sealed class CameraProvider
    {
        private readonly CameraConfig _cameraConfig;
        public CameraProvider(CameraConfig cameraConfig) {
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
    }
}