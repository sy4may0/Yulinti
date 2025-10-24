using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class LayerZeroAnimationPlan : IAnimationPlan, IAnimationPlanSpeedInjectable {
        private readonly SpeedInjectableOPAnimationPlayer _animationPlayer;

        public LayerZeroAnimationPlan(
            SpeedInjectableOPAnimationPlayer animationPlayer
        ) {
            _animationPlayer = animationPlayer;
        }

        public void Play() {
            _animationPlayer.Play();
        }

        public void Stop(Action onCompleted = null) {
            // Layer0は止めない。
            // コールバックは即時実行する。
            onCompleted?.Invoke();
        }

        public void StopLayer() {
            // Layer0は止めない。
            return;
        }

        // Layer0はブロックしない。
        public bool IsBlocking { get => false; }

        public void InjectSpeed(float speed) {
            _animationPlayer.InjectSpeed(speed);
        }
    }
}

