using UnityEngine;

namespace Yulinti.Dux.ConfigratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumDucisPuellae {
        [SerializeField] private FasciculusConfigurationumPuellaeStatus _configuratioPuellaeStatus;

        public FasciculusConfigurationumPuellaeStatus Status => _configuratioPuellaeStatus;
    }
}