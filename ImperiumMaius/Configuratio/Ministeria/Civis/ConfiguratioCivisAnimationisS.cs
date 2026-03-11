using Animancer;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisS", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisAnimationisS")]
    public sealed class ConfiguratioCivisAnimationisS : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private ClipTransition animatio;

        public override ITransition Animatio => animatio;
    }
}