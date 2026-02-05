using Animancer;
using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisUnicaeLM", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisUnicaeLM")]
    public sealed class ConfiguratioPuellaeAnimationisUnicaeLM : ConfiguratioPuellaeAnimationisBasis {
        [SerializeField] private LinearMixerTransition _animatio;

        public override ITransition Animatio => _animatio;
    }
}