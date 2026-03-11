using Animancer;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisS", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeAnimationisS")]
    public sealed class ConfiguratioPuellaeAnimationisS : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private ClipTransition animatio;

        public override ITransition Animatio => animatio;
    }
}