using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusDiscedens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Discedens")]
    public sealed class ConfiguratioCivisCustodiaeStatusDiscedens : ConfiguratioCivisCustodiaeStatusAttendensBasis, IConfiguratioCivisCustodiaeStatusDiscedens {
    }
}
