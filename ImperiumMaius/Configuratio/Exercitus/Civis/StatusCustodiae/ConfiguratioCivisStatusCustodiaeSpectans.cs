using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeSpectans",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Spectans")]
    public sealed class ConfiguratioCivisStatusCustodiaeSpectans : ConfiguratioCivisStatusCustodiaeIntuitusBasis, IConfiguratioCivisStatusCustodiaeSpectans {
        [Header("Intentio がこの割合(対Maxima)以上で Sequens へ")]
        [SerializeField] private float ratioIntentionisAdSequens = 0.5f;

        public float RatioIntentionisAdSequens => ratioIntentionisAdSequens;
    }
}
