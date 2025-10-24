using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class LayerZeroAnimationPlan : IAnimationPlan, IAnimationSpeedInjectable {
        private readonly IAnimationFacade _animationPlayer;
        private readonly int _layerIndex;

        public LayerZeroAnimationPlan(
            IAnimationFacade animationPlayer
        ) {
            _animationPlayer = animationPlayer;
            _layerIndex = 0;
        }

        public void Play() {
            _animationPlayer.Play();
        }

        public void Stop(Action onCompleted = null) {
            // Layer0は止めない。
            // コールバックは即時実行する。
            onCompleted?.Invoke();
        }

        public void StopLayer(float? fadeOverride = null) {
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

