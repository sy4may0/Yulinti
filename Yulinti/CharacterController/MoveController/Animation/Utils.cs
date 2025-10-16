using Animancer;
using UnityEngine;

namespace Yulinti.CharacterController {
    public static class AnimationUtils {
        public static AnimationState PlayWithSineEase(
            AnimancerLayer layer,
            AnimationClip clip,
            float fadeTime
        )
        {
            AnimationState state = layer.Play(clip, fadeTime);
            state.FadeGroup.SetEasing(Easing.Sine.InOut);
            return state;
        }

        public static void StopLayer(
            AnimancerLayer layer,
            float fadeTime
        )
        {
            // [TODO] Easingできるなら設定しよう。
            layer.StartFade(0f, fadeTime);
        }
    }
}