using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeSequens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Sequens")]
    public sealed class ConfiguratioCivisStatusCustodiaeSequens : ConfiguratioCivisStatusCustodiaeIntuitusBasis, IConfiguratioCivisStatusCustodiaeSequens {
    }
}
