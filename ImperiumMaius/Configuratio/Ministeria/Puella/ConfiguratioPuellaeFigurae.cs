using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFigurae", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeFigurae")]
    public sealed class ConfiguratioPuellaeFigurae : ScriptableObject, IConfiguratioPuellaeFigurae {
        [SerializeField] private ConfiguratioPuellaeFiguraePelvis _pelvis;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusSinister _genusSin;
        [SerializeField] private ConfiguratioPuellaeFiguraeGenusDexter _genusDex;

        public IConfiguratioPuellaeFiguraePelvis Pelvis => _pelvis;
        public IConfiguratioPuellaeFiguraeGenusSinister GenusSin => _genusSin;
        public IConfiguratioPuellaeFiguraeGenusDexter GenusDex => _genusDex;
    }
}
