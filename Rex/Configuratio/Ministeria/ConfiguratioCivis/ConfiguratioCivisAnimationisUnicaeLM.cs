using Animancer;
using UnityEngine;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisUnicaeLM", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationisUnicaeLM")]
    public sealed class ConfiguratioCivisAnimationisUnicaeLM : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private LinearMixerTransition animatio;

        public override ITransition Animatio => animatio;
    }
}