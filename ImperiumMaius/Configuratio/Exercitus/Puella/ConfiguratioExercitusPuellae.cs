using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusPuellae", menuName = "Yulinti/Configuratio/Exercitus/Puella/ConfiguratioExercitusPuellae")]
    public sealed class ConfiguratioExercitusPuellae : ScriptableObject, IConfiguratioExercitusPuellae {
        [SerializeField] private ConfiguratioPuellaeStatuum statuum;
        [SerializeField] private ConfiguratioPuellaeActionisSecundarius actionisSecundarius;
        [SerializeField] private ConfiguratioPuellaeVeletudinis veletudo;

        public IConfiguratioPuellaeStatuum Statuum => statuum;
        public IConfiguratioPuellaeActionisSecundarius ActionisSecundarius => actionisSecundarius;
        public IConfiguratioPuellaeVeletudinis Veletudo => veletudo;
    }
}