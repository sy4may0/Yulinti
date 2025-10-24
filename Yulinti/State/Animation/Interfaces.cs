using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IAnimationPlan {
        void Play();
        void Stop(Action onCompleted = null);
        void StopLayer(float? fadeOverride = null);
        bool IsBlocking { get; }
    }

    public interface IAnimationPlanSpeedInjectable {
        void InjectSpeed(float speed);
    }

    public interface IAnimancerFacade {
        void Play(int layerIndex);
        void StopLayer(int layerIndex);
        void SetOnEndCallback(int layerIndex, Action onCompleted);
        int getLayerCount();
    }
    public interface IAnimancerFacadeSpeedInjectable {
        void SetSpeed(float speed);
    }
}
