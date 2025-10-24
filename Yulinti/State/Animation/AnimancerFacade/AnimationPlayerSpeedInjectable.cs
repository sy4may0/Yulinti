using Animancer;
using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    public class AnimationPlayerSpeedInjectable : AnimationPlayer, IAnimancerFacadeSpeedInjectable
    {
        private readonly LinearMixerTransition _linearMixer;

        public AnimationPlayerSpeedInjectable(
            AnimancerComponent animancer,
            LinearMixerTransition linearMixer,
            float fadeTime,
            Easing easing
        ) : base(animancer, transition, fadeTime, easing)
        {
            _linearMixer = linearMixer ?? throw new ArgumentNullException(nameof(linearMixer));
        }

        public void SetSpeed(float speed)
        {
            if (_linearMixer.State == null) return;
            _linearMixer.State.Parameter = speed;
        }
    }
}