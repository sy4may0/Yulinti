using UnityEngine;
using Animancer;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaCrouchAnimationConfig : IFukaAnimationClipConfig {
        [Header("FukaCrouchAnimationConfig/Crouchアニメーション")]
        [SerializeField] private LinearMixerTransition _crouchAnimationMixer;
        [SerializeField] private float _fadeTime = 0.4f;
        [SerializeField] private Easing.Function _easing = Animancer.Easing.Function.Linear;
        [SerializeField] private bool _sync = false;
        [SerializeField] private bool _isBlocking = false;

        public ITransition Animation => _crouchAnimationMixer;
        public float FadeTime => _fadeTime;
        public Easing.Function Easing => _easing;
        public bool Sync => _sync;
        public bool IsBlocking => _isBlocking;
    }
}
        
        