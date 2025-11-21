using UnityEngine;

namespace Yulinti.Dux.ConfigratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumDucis {
        [SerializeField] private FasciculusConfigurationumDucisPuellae _configuratioPuellae;
        public FasciculusConfigurationumDucisPuellae Puellae => _configuratioPuellae;
    }
}