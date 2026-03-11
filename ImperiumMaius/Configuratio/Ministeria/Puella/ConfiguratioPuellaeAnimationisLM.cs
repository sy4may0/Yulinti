using Animancer;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisLM", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeAnimationisLM")]
    public sealed class ConfiguratioPuellaeAnimationisLM : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private LinearMixerTransition animatio;

        public override ITransition Animatio => animatio;
    }
}