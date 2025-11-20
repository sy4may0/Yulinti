using UnityEngine;

namespace Yulinti.Dux.ConfiguratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumDucisPuellae {
        [SerializeField] private FasciculusConfigurationumPuellaeStatus _configuratioPuellaeStatus;

        public FasciculusConfigurationumPuellaeStatus Status => _configuratioPuellaeStatus;
    }
}