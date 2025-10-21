using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite
{
    public class SpeedInjectableTPAnimationPlan : ThreePhaseAnimationPlan, IAnimationSpeedInjectable
    {
        private readonly LinearMixerTransition _startMixer;
        private readonly LinearMixerTransition _loopMixer;
        private readonly LinearMixerTransition _stopMixer;

        public SpeedInjectableTPAnimationPlan(
            AnimancerComponent animancer,
            int layerIndex,
            ITransition startClip,
            ITransition loopClip,
            ITransition stopClip,
            float fadeStart,
            float fadeLoop,
            float fadeStop
        ) : base(animancer, layerIndex, startClip, loopClip, stopClip, fadeStart, fadeLoop, fadeStop)
        {
            _startMixer = startClip as LinearMixerTransition;
            _loopMixer = loopClip as LinearMixerTransition;
            _stopMixer = stopClip as LinearMixerTransition;
        }

        public void InjectSpeed(float speed)
        {
            _startMixer?.State?.Parameter = speed;
            _loopMixer?.State?.Parameter = speed;
            _stopMixer?.State?.Parameter = speed;
        }
    }
}