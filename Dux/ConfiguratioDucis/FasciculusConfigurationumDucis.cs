using UnityEngine;

namespace Yulinti.Dux.ConfiguratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumDucis {
        [SerializeField] private FasciculusConfigurationumDucisPuellae _configuratioPuellae;
        public FasciculusConfigurationumDucisPuellae Puellae => _configuratioPuellae;
    }
}