using Animancer;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisUnicae", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisUnicae")]
    public sealed class ConfiguratioPuellaeAnimationisUnicae : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private ClipTransition _animatio;

        public override ITransition Animatio => _animatio;
    }
}