using UnityEngine;
using Animancer;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaStandardBaseAnimationConfig : IFukaAnimationClipConfig {
        [Header("FukaStandardBaseAnimationConfig/StandardBaseアニメーション")]
        [SerializeField] private LinearMixerTransition _standardBaseAnimationMixer;
        [SerializeField] private float _fadeTime = 0.4f;
        [SerializeField] private Easing.Function _easing = Animancer.Easing.Function.Linear;
        [SerializeField] private bool _sync = false;
        [SerializeField] private bool _isBlocking = false;

        public ITransition Animation => _standardBaseAnimationMixer;
        public float FadeTime => _fadeTime;
        public Easing.Function Easing => _easing;
        public bool Sync => _sync;
        public bool IsBlocking => _isBlocking;
    }
}