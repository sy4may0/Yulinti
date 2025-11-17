using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationum {
        [SerializeField] private FasciculusConfigurationumInput _input;
        [SerializeField] private FasciculusConfigurationumCamera _camera;
        [SerializeField] private FasciculusConfigurationumPuellae _puellae;

        public FasciculusConfigurationumInput Input => _input;
        public FasciculusConfigurationumCamera Camera => _camera;
        public FasciculusConfigurationumPuellae Puellae => _puellae;
    }
}