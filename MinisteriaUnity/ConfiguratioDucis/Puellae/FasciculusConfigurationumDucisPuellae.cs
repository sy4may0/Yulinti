using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumDucisPuellae {
        [SerializeField] private ConfiguratioPuellaeInTerrae _configuratioInTerrae;
        [SerializeField] private FasciculusConfigurationumPuellaeStatus _configuratioPuellaeStatus;

        public ConfiguratioPuellaeInTerrae InTerrae => _configuratioInTerrae;
        public FasciculusConfigurationumPuellaeStatus Status => _configuratioPuellaeStatus;
    }
}
