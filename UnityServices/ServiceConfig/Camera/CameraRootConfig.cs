using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class CameraRootConfig {
        [SerializeField] private MainCameraConfig _mainCameraConfig;

        public MainCameraConfig MainCameraConfig => _mainCameraConfig;
    }
}