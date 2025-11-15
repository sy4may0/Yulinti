using UnityEngine;
using Yulinti.ConfiguratioMinisterii;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class ServiceRootConfig {
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private FasciculusConfigurationumCamera _cameraConfig;
        [SerializeField] private FukaRootConfig _fukaConfig;

        public InputConfig InputConfig => _inputConfig;
        public FasciculusConfigurationumCamera CameraConfig => _cameraConfig;
        public FukaRootConfig FukaConfig => _fukaConfig;
    }
}