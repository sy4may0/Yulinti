using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerBaseAnimationConfig {
        [Header("BaseAnimationConfig/Baseアニメーション")]
        [Tooltip("Baseアニメーションミキサー")]
        [SerializeField] private LinearMixerTransition _baseAnimationMixer;

        public LinearMixerTransition BaseAnimationMixer => _baseAnimationMixer;
    }
}