using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerCrouchAnimationConfig {
        [Header("CrouchAnimation/Crouchアニメーション")]
        [Tooltip("Crouchアニメーションミキサー")]
        [SerializeField] private LinearMixerTransition _crouchAnimationMixer;
        [Tooltip("フェード時間")]
        [SerializeField] private float _fadeTime = 0.4f;

        public LinearMixerTransition CrouchAnimationMixer => _crouchAnimationMixer;
        public float FadeTime => _fadeTime;
    }
}