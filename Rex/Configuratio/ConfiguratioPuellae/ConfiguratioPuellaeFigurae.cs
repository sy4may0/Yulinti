using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFigurae : IConfiguratioPuellaeFigurae {
        [SerializeField] private ConfiguratioPuellaeFiguraePelvis _pelvis;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusSin _genusSin;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusDex _genusDex;

        public IConfiguratioPuellaeFiguraePelvis Pelvis => _pelvis;
        public IConfiguratioPuellaeFiguraeGenus GenusSin => _genusSin;
        public IConfiguratioPuellaeFiguraeGenus GenusDex => _genusDex;
    }
}
