using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public class ThreePhaseAnimationPlayer : IAnimancerFacade {
        private readonly AnimancerComponent _animancer;
        private readonly ITransition _startTransition;
        private readonly ITransition _loopTransition;
        private readonly ITransition _endTransition;
        private readonly float _fadeTime;
        private readonly Easing _easing;
        private readonly int _layerIndex;

        public ThreePhaseAnimationPlayer(
            AnimancerComponent animancer,
            ITransition startTransition,
            ITransition loopTransition,
            ITransition endTransition,
            int layerIndex,
            float fadeTime,
            Easing easing
        ) {
            _animancer = animancer ?? throw new ArgumentNullException(nameof(animancer));
            _startTransition = startTransition;
            _loopTransition = loopTransition;
            _endTransition = endTransition;
            _fadeTime = fadeTime;
            _easing = easing ?? Easing.Cubic.InOut;
            _layerIndex = layerIndex;
        }

        public int GetLayerIndex() {
            return _layerIndex;
        }

        private bool TryGetLayer(out AnimancerLayer layer)
        {
            layer = null;
            var layers = _animancer?.Layers;
            if (layers == null) return false;
            if (_layerIndex < 0) return false;
            layer = layers[_layerIndex];
            return layer != null;
        }

        public void PlayStart() {
            if (!TryGetLayer(out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.Play(_startTransition, _fadeTime);
        }

        public void PlayLoop() {
            if (!TryGetLayer(out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.Play(_loopTransition, _fadeTime);
        }

        public void PlayEnd() {
            if (!TryGetLayer(out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.Play(_endTransition, _fadeTime);
        }

        public void StopLayer() {
            if (!TryGetLayer(out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.StartFade(0f, _fadeTime);
        }

        public void SetOnEndCallback(Action onEnd) {
            if (!TryGetLayer(out var layer)) return;
            AnimancerState state = layer.State;
            if (state != null && state.Events(this, out AnimancerEvent.Sequence events))
            {
                events.OnEnd = onEnd;
            }
        }
    }
}