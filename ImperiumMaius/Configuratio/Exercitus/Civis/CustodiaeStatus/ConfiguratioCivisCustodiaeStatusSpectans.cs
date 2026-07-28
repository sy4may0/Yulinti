using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusSpectans",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Spectans")]
    public sealed class ConfiguratioCivisCustodiaeStatusSpectans : ConfiguratioCivisCustodiaeStatusIntuitusBasis, IConfiguratioCivisCustodiaeStatusSpectans {
        [Header("Intentio がこの割合(対Maxima)以上で Sequens へ")]
        [SerializeField] private float ratioIntentionisAdSequens = 0.5f;

        public float RatioIntentionisAdSequens => ratioIntentionisAdSequens;
    }
}
