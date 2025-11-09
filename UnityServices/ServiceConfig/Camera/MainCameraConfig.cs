using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class MainCameraConfig : ICameraConfig {
        [Header("CameraService/MainCamera設定")]
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
    }
}