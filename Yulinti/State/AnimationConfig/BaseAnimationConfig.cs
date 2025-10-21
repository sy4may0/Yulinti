using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class BaseAnimationConfig {
        [SerializeField] private LinearMixerTransition _baseAnimationMixer;

        public LinearMixerTransition BaseAnimationMixer => _baseAnimationMixer;
    }
}