using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class FukaRootConfig {
        [SerializeField] private ConfiguratioPuellaeOssis _configuratioPuellaeOssis;
        [SerializeField] private ConfiguratioPuellaeLoci _configuratioPuellaeLoci;
        [SerializeField] private FukaAnimationConfig _fukaAnimationConfig;
        [SerializeField] private FasciculusConfigurationumPuellaeFigurae _fasciculusConfigurationumPuellaeFigurae;
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae _configuratioPuellaeRelationisTerrae;

        public ConfiguratioPuellaeOssis Ossis => _configuratioPuellaeOssis;
        public ConfiguratioPuellaeLoci Locus => _configuratioPuellaeLoci;
        public FukaAnimationConfig FukaAnimationConfig => _fukaAnimationConfig;
        public FasciculusConfigurationumPuellaeFigurae Figura => _fasciculusConfigurationumPuellaeFigurae;
        public ConfiguratioPuellaeRelationisTerrae RelatioTerrae => _configuratioPuellaeRelationisTerrae;
    }
}