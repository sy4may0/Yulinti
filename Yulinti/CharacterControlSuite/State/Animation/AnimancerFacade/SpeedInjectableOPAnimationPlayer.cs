using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public class SpeedInjectableOPAnimationPlayer : OnePhaseAnimationPlayer, IAnimancerFacadeSpeedInjectable {
        private readonly LinearMixerTransition _speedInjectableTransition;

        public SpeedInjectableOPAnimationPlayer(
            AnimancerComponent animancer,
            LinearMixerTransition transition,
            int layerIndex,
            float fadeTime = 0f,
            Easing easing = Easing.Cubic.InOut
        ) : base(animancer, transition, layerIndex, fadeTime, easing) {
            _speedInjectableTransition = transition;
        }

        public void InjectSpeed(float speed) {
            AnimancerState state = _speedInjectableTransition.State;
            if (state == null) return;
            state.Parameter = speed;
        }
    }
}
