using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;
        [SerializeField] private ConfiguratioCivisCustodiaeIctuum custodiaeIctuum;
        [SerializeField] private ConfiguratioCivisCustodiaeStatus custodiaeStatus;
        [SerializeField] private ConfiguratioCivisGenerationis generationis;

        public IConfiguratioCivisStatuum Statuum => statuum;
        public IConfiguratioCivisCustodiaeIctuum CustodiaeIctuum => custodiaeIctuum;
        public IConfiguratioCivisCustodiaeStatus CustodiaeStatus => custodiaeStatus;
        public IConfiguratioCivisGenerationis Generationis => generationis;
    }
}