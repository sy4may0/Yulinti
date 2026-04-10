using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;
        [SerializeField] private ConfiguratioCivisCustodiae custodiae;
        [SerializeField] private ConfiguratioCivisGenerationis generationis;

        public IConfiguratioCivisStatuum Statuum => statuum;
        public IConfiguratioCivisCustodiae Custodiae => custodiae;
        public IConfiguratioCivisGenerationis Generationis => generationis;
    }
}