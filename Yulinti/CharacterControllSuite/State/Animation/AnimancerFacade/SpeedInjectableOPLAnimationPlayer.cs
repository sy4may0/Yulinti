using UnityEngine;
using Animancer;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    // スピードを注入できる1フェースループ再生アニメーションプレイヤー
    public class SpeedInjectableOPLAnimationPlayer : OnePhaseLoopAnimationPlayer, IAnimancerFacadeSpeedInjectable {
        private readonly LinearMixerTransition _speedInjectableLoopTransition;

        public SpeedInjectableOPLAnimationPlayer(
            AnimancerComponent animancer,
            LinearMixerTransition transition,
            int layerIndex,
            float fadeTime,
            Easing.Function easing
        ) : base(animancer, transition, layerIndex, fadeTime, easing) {
            _speedInjectableLoopTransition = transition;
        }
        public void InjectSpeed(float speed) {
            _speedInjectableLoopTransition.State.Parameter = speed;
        }
    }
}
