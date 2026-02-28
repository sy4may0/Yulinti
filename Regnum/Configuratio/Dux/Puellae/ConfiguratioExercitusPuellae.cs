using UnityEngine;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusPuellae", menuName = "Yulinti/Rex/ConfiguratioExercitusPuellae")]
    public sealed class ConfiguratioExercitusPuellae : ScriptableObject, IConfiguratioExercitusPuellae {
        [SerializeField] private ConfiguratioPuellaeStatuum statuum;
        [SerializeField] private ConfiguratioPuellaeActionisSecundarius actionisSecundarius;
        [SerializeField] private ConfiguratioPuellaeVeletudinis veletudo;
        [SerializeField] private ConfiguratioPuellaePersonae personae;

        public IConfiguratioPuellaeStatuum Statuum => statuum;
        public IConfiguratioPuellaeActionisSecundarius ActionisSecundarius => actionisSecundarius;
        public IConfiguratioPuellaeVeletudinis Veletudo => veletudo;
        public IConfiguratioPuellaePersonae Personae => personae;
    }
}