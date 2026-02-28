using Animancer;
using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisUnicae", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisUnicae")]
    public sealed class ConfiguratioPuellaeAnimationisUnicae : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private ClipTransition _animatio;

        public override ITransition Animatio => _animatio;
    }
}