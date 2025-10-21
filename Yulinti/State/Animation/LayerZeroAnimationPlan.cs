using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class LayerZeroAnimationPlan : IAnimationPlan, IAnimationSpeedInjectable {
        private readonly AnimancerComponent _animancer;
        private LinearMixerTransition _baseTransition;

        public LayerZeroAnimationPlan(
            AnimancerComponent animancer,
            LinearMixerTransition baseTransition
        ) {
            _animancer = animancer;
            _baseTransition = baseTransition;
        }

        public void Play() {
            _animancer.Layers[0].Play(_baseTransition);
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
            _baseTransition?.State?.Parameter = speed;
        }
    }
}

