using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFigurae : IConfiguratioPuellaeFigurae {
        [SerializeField] private ConfiguratioPuellaeFiguraePelvis _pelvis;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusSinister _genusSin;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusDexter _genusDex;

        public IConfiguratioPuellaeFiguraePelvis Pelvis => _pelvis;
        public IConfiguratioPuellaeFiguraeGenusSinister GenusSin => _genusSin;
        public IConfiguratioPuellaeFiguraeGenusDexter GenusDex => _genusDex;
    }
}
