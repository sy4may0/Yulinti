using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusCircumitus",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Circumitus")]
    public sealed class ConfiguratioCivisCustodiaeStatusCircumitus : ConfiguratioCivisCustodiaeStatusAttendensBasis, IConfiguratioCivisCustodiaeStatusCircumitus {
    }
}
