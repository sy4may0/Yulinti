using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumPuellae {
        [SerializeField] private ConfiguratioPuellaeOssis _configuratioPuellaeOssis;
        [SerializeField] private ConfiguratioPuellaeLoci _configuratioPuellaeLoci;
        [SerializeField] private ConfiguratioPuellaeAnimationis _configuratioPuellaeAnimationis;
        [SerializeField] private FasciculusConfigurationumPuellaeFigurae _fasciculusConfigurationumPuellaeFigurae;
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae _configuratioPuellaeRelationisTerrae;

        public ConfiguratioPuellaeOssis Ossis => _configuratioPuellaeOssis;
        public ConfiguratioPuellaeLoci Locus => _configuratioPuellaeLoci;
        public ConfiguratioPuellaeAnimationis Animationis => _configuratioPuellaeAnimationis;
        public FasciculusConfigurationumPuellaeFigurae Figura => _fasciculusConfigurationumPuellaeFigurae;
        public ConfiguratioPuellaeRelationisTerrae RelatioTerrae => _configuratioPuellaeRelationisTerrae;
    }
}