using Animancer;

namespace Yulinti.UnityServices.Internal.AnimationUtils {
    public class AnimationPlan : IAnimationPlan {
        private readonly ITransition _transition;
        private readonly float _fadeTime;
        private readonly Easing.Function _easing;
        private readonly bool _sync;
        private readonly bool _isBlocking;

        public AnimationPlan(
            ITransition transition, 
            float fadeTime, Easing.Function easing, 
            bool sync = false, bool isBlocking = false)
        {
            _transition = transition;
            _fadeTime = fadeTime;
            _easing = easing;
            _sync = sync;
            _isBlocking = isBlocking;
        }

        public ITransition Transition => _transition;
        public float FadeTime => _fadeTime;
        public Easing.Function Easing => _easing;
        public bool Sync => _sync;
        public bool IsBlocking => _isBlocking;
    }

    public class AnimationPlanSpeedInjectable : IAnimationPlan, IAnimationPlanSpeedInjectable {
        private readonly LinearMixerTransition _transition;
        private readonly float _fadeTime;
        private readonly Easing.Function _easing;
        private readonly bool _sync;
        private readonly bool _isBlocking;

        public AnimationPlanSpeedInjectable(
            LinearMixerTransition transition,
            float fadeTime, Easing.Function easing,
            bool sync = false, bool isBlocking = false)
        {
            _transition = transition;
            _fadeTime = fadeTime;
            _easing = easing;
            _sync = sync;
            _isBlocking = isBlocking;
        }

        public ITransition Transition => _transition;
        public float FadeTime => _fadeTime;
        public Easing.Function Easing => _easing;
        public bool Sync => _sync;
        public bool IsBlocking => _isBlocking;
        public void InjectSpeed(float speed) {
            _transition.State.Parameter = speed;
        }
    }
}
