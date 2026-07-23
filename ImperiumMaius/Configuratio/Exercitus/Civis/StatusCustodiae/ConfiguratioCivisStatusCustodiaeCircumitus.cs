using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeCircumitus",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Circumitus")]
    public sealed class ConfiguratioCivisStatusCustodiaeCircumitus : ConfiguratioCivisStatusCustodiaeAttendensBasis, IConfiguratioCivisStatusCustodiaeCircumitus {
    }
}
