using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumPuellaeFigurae {
        [SerializeField] private ConfiguratioPuellaeFiguraePelvis _configuratioPuellaeFiguraePelvis;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusSin _configuratioPuellaeFiguraeGenusSin;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusDex _configuratioPuellaeFiguraeGenusDex;

        public ConfiguratioPuellaeFiguraePelvis Pelvis => _configuratioPuellaeFiguraePelvis;
        public ConfiguratioPuellaeFiguraeGenusSin GenusSin => _configuratioPuellaeFiguraeGenusSin;
        public ConfiguratioPuellaeFiguraeGenusDex GenusDex => _configuratioPuellaeFiguraeGenusDex;
    }
}
        