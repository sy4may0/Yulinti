using UnityEngine;
using Animancer;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisUnicae", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationisUnicae")]
    public sealed class ConfiguratioCivisAnimationisUnicae : ConfiguratioCivisAnimationisBasis {
        [SerializeField] private ClipTransition animatio;

        public override ITransition Animatio => animatio;
    }
}