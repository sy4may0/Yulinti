using Animancer;
using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public static class AnimationUtils {
        public static AnimancerState PlayWithSineEase(
            AnimancerLayer layer,
            ITransition clip,
            float fadeTime
        )
        {
            AnimancerState state = layer.Play(clip, fadeTime);
            layer.FadeGroup.SetEasing(Easing.Cubic.InOut);
            return state;
        }

        public static void StopLayer(
            AnimancerLayer layer,
            float fadeTime
        )
        {
            layer.StartFade(0f, fadeTime);
            layer.FadeGroup.SetEasing(Easing.Cubic.InOut);
        }
    }
}