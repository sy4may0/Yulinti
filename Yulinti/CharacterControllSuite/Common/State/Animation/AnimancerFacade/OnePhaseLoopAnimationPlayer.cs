using UnityEngine;
using Animancer;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    // ループ再生する1フェースアニメーションプレイヤー
    public class OnePhaseLoopAnimationPlayer : IAnimancerFacade {
        private readonly AnimancerComponent _animancer;
        private readonly ITransition _loopTransition;
        private readonly int _layerIndex;
        private readonly float _fadeTime;
        private readonly Easing.Function _easing;
        private readonly bool _syncLayerZero;

        private AnimancerState _currentState;

        public OnePhaseLoopAnimationPlayer(
            AnimancerComponent animancer,
            ITransition loopTransition,
            int layerIndex,
            float fadeTime,
            Easing.Function easing,
            bool syncLayerZero = true
        ) {
            _animancer = animancer;
            _loopTransition = loopTransition;
            _layerIndex = layerIndex;
            _fadeTime = fadeTime;
            _easing = easing;
            _syncLayerZero = syncLayerZero;
        }

        public bool HasTransition { get => _loopTransition != null; }
        public int GetLayerIndex { get => _layerIndex; }

        public void Play() {
            AnimancerLayer layer = _animancer.Layers[_layerIndex];
            if (layer == null) return;

            if (HasTransition)  {
                _currentState = _animancer.Layers[_layerIndex].Play(_loopTransition, _fadeTime);
                layer.FadeGroup.SetEasing(_easing);
            }

            if (_syncLayerZero) {
                AnimancerLayer layerZero = _animancer.Layers[0];
                if (layerZero == null) return;

                float previousNTime = layerZero.CurrentState.NormalizedTime;
                _currentState.NormalizedTime = previousNTime;

            }
        }
        
        public void StopLayer() {
            AnimancerLayer layer = _animancer.Layers[_layerIndex];
            if (layer == null) return;

            layer.StartFade(0f, _fadeTime);
            layer.FadeGroup.SetEasing(_easing);
            _currentState = null;
        }

        public void OnEnd(Action onEnd) {
            onEnd?.Invoke();
        }
    }
}
