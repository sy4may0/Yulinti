using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public class OnePhaseAnimationPlayer : IAnimancerFacade {
        private readonly AnimancerComponent _animancer;
        private readonly ITransition _loopTransition;
        private readonly int _layerIndex;
        private readonly float _fadeTime = 0f;
        private readonly Easing _easing = Easing.Cubic.InOut;

        public OnePhaseAnimationPlayer(
            AnimancerComponent animancer,
            ITransition loopTransition,
            int layerIndex,
            float fadeTime = 0f,
            Easing easing = Easing.Cubic.InOut
        ) {
            _animancer = animancer;
            _loopTransition = loopTransition;
            _fadeTime = fadeTime;
            _easing = easing;
            _layerIndex = layerIndex;
        }

        public int GetLayerIndex() {
            return _layerIndex;
        }

        public void Play() {
            if (!TryGetLayer(out var layer)) return;
            layer.FadeGroup.SetEasing(_easing);
            layer.Play(_loopTransition, _fadeTime);
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
