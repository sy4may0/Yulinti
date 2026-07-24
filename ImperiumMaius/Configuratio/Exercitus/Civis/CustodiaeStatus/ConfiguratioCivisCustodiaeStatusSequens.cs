using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusSequens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Sequens")]
    public sealed class ConfiguratioCivisCustodiaeStatusSequens : ConfiguratioCivisCustodiaeStatusIntuitusBasis, IConfiguratioCivisCustodiaeStatusSequens {
    }
}
