using UnityEngine;

namespace Yulinti.ServiceSuite {
    [System.Serializable]
    public class CameraConfig {
        [Header("CameraConfig/Camera設定")]
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
    }
}