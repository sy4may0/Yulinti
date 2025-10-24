using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public class SpeedInjectableTPAnimationPlayer : ThreePhaseAnimationPlayer, IAnimancerFacadeSpeedInjectable {
        // 速度注入可能のITransitionを保持する配列
        private readonly List<LinearMixerTransition> _speedInjectableTransitions;

        public SpeedInjectableTPAnimationPlayer(
            AnimancerComponent animancer,
            ITransition startTransition,
            ITransition loopTransition,
            ITransition endTransition,
            int layerIndex,
            float fadeTime,
            Easing easing
        ) : base(animancer, startTransition, loopTransition, endTransition, fadeTime, easing, layerIndex) {
            _speedInjectableTransitions = new List<LinearMixerTransition>(3);
            if (startTransition is LinearMixerTransition startMixer) {
                _speedInjectableTransitions.Add(startMixer);
            }
            if (loopTransition is LinearMixerTransition loopMixer) {
                _speedInjectableTransitions.Add(loopMixer);
            }
            if (endTransition is LinearMixerTransition endMixer) {
                _speedInjectableTransitions.Add(endMixer);
            }
        }

        public void InjectSpeed(float speed) {
            foreach (LinearMixerTransition mixer in _speedInjectableTransitions) {
                AnimancerState state = mixer.State;
                if (state == null) continue;
                state.Parameter = speed;
            }
        }
    }
}