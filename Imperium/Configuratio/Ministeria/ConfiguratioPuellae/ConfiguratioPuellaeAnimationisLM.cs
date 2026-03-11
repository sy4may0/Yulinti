using Animancer;
using UnityEngine;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisLM", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisLM")]
    public sealed class ConfiguratioPuellaeAnimationisLM : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private LinearMixerTransition animatio;

        public override ITransition Animatio => animatio;
    }
}