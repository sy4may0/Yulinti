using UnityEngine;
using Animancer;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IAnimationPlan {
        void Play();
        void Stop(Action onCompleted = null);
        void StopLayer();
        void InjectSpeed(float speed);
        bool IsBlocking { get; }
    }

    public interface IAnimancerFacade {
        int GetLayerIndex { get; }
        bool HasTransition { get; }
        void Play();
        void StopLayer();
        void OnEnd(Action onEnd);
    }

    public interface IAnimancerFacadeSpeedInjectable {
        void InjectSpeed(float speed);
    }
}
