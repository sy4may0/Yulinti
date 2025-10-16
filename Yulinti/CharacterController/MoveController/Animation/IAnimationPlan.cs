using UnityEngine;

namespace Yulinti.CharacterController {
    public interface IAnimationPlan {
        void Play();
        void Stop(Action onCompleted = null);
        void StopLayer(float? fadeOverride = null);
        bool IsBlocking { get; }
    }
}