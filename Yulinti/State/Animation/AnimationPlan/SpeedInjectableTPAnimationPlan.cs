using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite
{
    public class SpeedInjectableTPAnimationPlan : ThreePhaseAnimationPlan, IAnimationPlanSpeedInjectable
    {
        private readonly AnimationPlayerSpeedInjectable _startMixer;
        private readonly AnimationPlayerSpeedInjectable _loopMixer;
        private readonly AnimationPlayerSpeedInjectable _stopMixer;

        public SpeedInjectableTPAnimationPlan(
            AnimationPlayerSpeedInjectable startMixer,
            AnimationPlayerSpeedInjectable loopMixer,
            AnimationPlayerSpeedInjectable stopMixer,
            int layerIndex,
        ) : base(animancer, layerIndex, startMixer, loopMixer, stopMixer)
        {
            _startMixer = startMixer;
            _loopMixer = loopMixer;
            _stopMixer = stopMixer;
        }

        public void InjectSpeed(float speed)
        {
            _startMixer?.SetSpeed(speed);
            _loopMixer?.SetSpeed(speed);
            _stopMixer?.SetSpeed(speed);
        }
    }
}