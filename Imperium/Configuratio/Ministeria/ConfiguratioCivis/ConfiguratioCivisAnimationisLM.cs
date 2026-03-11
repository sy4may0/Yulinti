using Animancer;
using UnityEngine;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisLM", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationisLM")]
    public sealed class ConfiguratioCivisAnimationis : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private LinearMixerTransition animatio;

        public override ITransition Animatio => animatio;
    }
}