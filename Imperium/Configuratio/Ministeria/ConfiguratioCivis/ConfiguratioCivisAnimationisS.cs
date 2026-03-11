using Animancer;
using UnityEngine;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisS", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationisS")]
    public sealed class ConfiguratioCivisAnimationisS : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private ClipTransition animatio;

        public override ITransition Animatio => animatio;
    }
}