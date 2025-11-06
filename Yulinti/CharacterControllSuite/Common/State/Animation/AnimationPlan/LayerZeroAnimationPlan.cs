using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class LayerZeroAnimationPlan : IAnimationPlan {
        private readonly SpeedInjectableOPLAnimationPlayer _animationPlayer;

        public LayerZeroAnimationPlan(
            SpeedInjectableOPLAnimationPlayer animationPlayer
        ) {
            _animationPlayer = animationPlayer;
        }

        public void Play() {
            _animationPlayer.Play();
        }

        public void Stop(Action onCompleted = null) {
            _animationPlayer.OnEnd(onCompleted);
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

