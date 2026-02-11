using UnityEngine;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Rex/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;
        [SerializeField] private ConfiguratioCivisCustodiae custodiae;

        public IConfiguratioCivisStatuum Statuum => statuum;
        public IConfiguratioCivisCustodiae Custodiae => custodiae;
    }
}