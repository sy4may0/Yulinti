using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;
        [SerializeField] private ConfiguratioCivisCustodiaeIctuum custodiaeIctuum;
        [SerializeField] private ConfiguratioCivisCustodiaeStatuum custodiaeStatuum;
        [SerializeField] private ConfiguratioCivisGenerationis generationis;
        [SerializeField] private ConfiguratioCiviumPersonarum personae;

        public IConfiguratioCivisStatuum Statuum => statuum;
        public IConfiguratioCivisCustodiaeIctuum CustodiaeIctuum => custodiaeIctuum;
        public IConfiguratioCivisCustodiaeStatuum CustodiaeStatuum => custodiaeStatuum;
        public IConfiguratioCivisGenerationis Generationis => generationis;
        public IConfiguratioCiviumPersonarum Personae => personae;
    }
}