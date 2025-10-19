using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class CrouchAnimationConfig {
        [Header("CrouchAnimation/Crouchアニメーション")]
        [Tooltip("Crouchアニメーションミキサー")]
        [SerializeField] public LinearMixerTransition CrouchAnimationMixer;
        [Tooltip("フェード時間")]
        [SerializeField] public float FadeTime = 0.4f;
    }
}