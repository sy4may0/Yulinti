using Animancer;
using UnityEngine;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisS", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisS")]
    public sealed class ConfiguratioPuellaeAnimationisS : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private ClipTransition animatio;

        public override ITransition Animatio => animatio;
    }
}