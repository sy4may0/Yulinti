using UnityEngine;
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
        int GetLayerIndex();
        void StopLayer();
        void SetOnEndCallback(Action onEnd);
    }

    public interface IAnimancerFacadeSpeedInjectable {
        void InjectSpeed(float speed);
    }
}
