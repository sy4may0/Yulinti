using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class ServiceRootConfig {
        [SerializeField] private FasciculusConfigurationumInput _configurationesInput;
        [SerializeField] private FasciculusConfigurationumCamera _configurationesCamera;
        [SerializeField] private FukaRootConfig _fukaConfig;

        public FasciculusConfigurationumInput Input => _configurationesInput;
        public FasciculusConfigurationumCamera Camera => _configurationesCamera;
        public FukaRootConfig FukaConfig => _fukaConfig;
    }
}