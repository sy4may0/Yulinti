using Animancer;

namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaAnimationClipConfig {
        ITransition Animation { get; }
        float FadeTime { get; }
        Easing.Function Easing { get; }
        bool Sync { get; }
        bool IsBlocking { get; }
    }
}