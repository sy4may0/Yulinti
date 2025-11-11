using UnityEngine;
using Animancer;
using System;

namespace Yulinti.UnityServices.Internal.AnimationUtils {
    public interface IAnimationLayer {
        int LayerIndex { get; }
        IAnimationPlan CurrentAnimationPlan { get; }
        void PlayRequest(IAnimationPlan animationPlan, Action onCompleted, bool force, bool lockNext);
        void ForceStopRequest();
        void InjectSpeed(float speed);
        void Tick(float deltaTime);
        float GetSyncTime();
        void SetSyncTime(float time);
        bool IsBlocking { get; }
    }
}