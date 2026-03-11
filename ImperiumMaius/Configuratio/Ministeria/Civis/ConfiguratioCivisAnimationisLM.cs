using Animancer;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisLM", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisAnimationisLM")]
    public sealed class ConfiguratioCivisAnimationis : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private LinearMixerTransition animatio;

        public override ITransition Animatio => animatio;
    }
}