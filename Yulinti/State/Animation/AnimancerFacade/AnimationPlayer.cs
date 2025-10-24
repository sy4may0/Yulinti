using Animancer;
using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    public class AnimationPlayer : IAnimancerFacade
    {
        private readonly AnimancerComponent _animancer;
        private readonly ITransition _transition;
        private readonly float _fadeTime;
        private readonly Easing _easing;
    
        public AnimationPlayer(
            AnimancerComponent animancer,
            ITransition transition,
            float fadeTime,
            Easing easing
        )
        {
            _animancer  = animancer ?? throw new ArgumentNullException(nameof(animancer));
            _transition = transition ?? throw new ArgumentNullException(nameof(transition));
            _fadeTime = fadeTime;
            _easing = easing;
        }
    
        private bool TryGetLayer(int layerIndex, out AnimancerLayer layer)
        {
            layer = null;
            var layers = _animancer?.Layers;
            if (layers == null) return false;
            if (layerIndex < 0 || layerIndex >= layers.Count) return false;
            layer = layers[layerIndex];
            return layer != null;
        }
    
        public void Play(int layerIndex)
        {
            if (!TryGetLayer(layerIndex, out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.Play(_transition, _fadeTime);
        }

        public void StopLayer(int layerIndex)
        {
            if (!TryGetLayer(layerIndex, out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.StartFade(0f, _fadeTime);
        }
    
        public void SetOnEndCallback(int layerIndex, Action onEnd)
        {
            if (onEnd == null) return;
            if (!TryGetLayer(layerIndex, out var layer)) return;
    
            AnimancerState state = layer.State;
            if (state != null && state.Events(this, out AnimancerEvent.Sequence events))
            {
                events.OnEnd = onEnd;
            }
        }

        public int getLayerCount() {
            return _animancer.Layers.Count;
        }
    }
}