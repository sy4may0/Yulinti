using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class ServiceRootConfig {
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private CameraRootConfig _cameraConfig;
        [SerializeField] private FukaRootConfig _fukaConfig;

        public InputConfig InputConfig => _inputConfig;
        public CameraRootConfig CameraConfig => _cameraConfig;
        public FukaRootConfig FukaConfig => _fukaConfig;
    }
}