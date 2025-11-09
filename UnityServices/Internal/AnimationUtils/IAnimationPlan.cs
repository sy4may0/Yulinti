using Animancer;

namespace Yulinti.UnityServices.Internal.AnimationUtils {
    public interface IAnimationPlan {
        ITransition Transition { get; }
        float FadeTime { get; }
        Easing.Function Easing { get; }
        bool Sync { get; }
        bool IsBlocking { get; }
    }

    public interface IAnimationPlanSpeedInjectable {
        void InjectSpeed(float speed);
    }
}