using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Rex/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;
        [SerializeField] private ConfiguratioCivisCustodiae custodiae;

        public IConfiguratioCivisStatuum Statuum => statuum;
        public IConfiguratioCivisCustodiae Custodiae => custodiae;
    }
}