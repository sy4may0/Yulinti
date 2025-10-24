using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class OnePhaseAnimationPlan : IAnimationPlan {
        private readonly SpeedInjectableOPAnimationPlayer _animationPlayer;

        public OnePhaseAnimationPlan(
            OnePhaseAnimationPlayer animationPlayer
        ) {
            _animationPlayer = animationPlayer;
        }

        public void Play() {
            _animationPlayer.Play();
        }

        public void Stop(Action onCompleted = null) {
            onCompleted?.Invoke();
        }

        public void StopLayer() {
            _animationPlayer.StopLayer();
        }

        public bool IsBlocking { get => false; }

        public void InjectSpeed(float speed) {
            if (_animationPlayer is IAnimancerFacadeSpeedInjectable speedInjectable) {
                speedInjectable.InjectSpeed(speed);
            }
        }
    }
}