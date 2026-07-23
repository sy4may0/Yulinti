using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeDiscedens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Discedens")]
    public sealed class ConfiguratioCivisStatusCustodiaeDiscedens : ConfiguratioCivisStatusCustodiaeAttendensBasis, IConfiguratioCivisStatusCustodiaeDiscedens {
    }
}
