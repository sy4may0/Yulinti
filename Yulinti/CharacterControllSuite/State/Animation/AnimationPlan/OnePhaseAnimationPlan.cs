using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class OnePhaseLoopAnimationPlan : IAnimationPlan {
        private readonly OnePhaseLoopAnimationPlayer _animationPlayer;

        public OnePhaseLoopAnimationPlan(
            OnePhaseLoopAnimationPlayer animationPlayer
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

        // ループ再生するアニメーションはブロックしない。
        public bool IsBlocking { get => false; }

        public void InjectSpeed(float speed) {
            if (_animationPlayer is IAnimancerFacadeSpeedInjectable speedInjectable) {
                speedInjectable.InjectSpeed(speed);
            }
        }
    }
}