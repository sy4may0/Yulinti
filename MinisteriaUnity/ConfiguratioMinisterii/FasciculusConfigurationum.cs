using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationum {
        [SerializeField] private FasciculusConfigurationumPuellae _puellae;

        public FasciculusConfigurationumPuellae Puellae => _puellae;
    }
}