using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IAnimationPlan {
        void Play();
        void Stop(Action onCompleted = null);
        void StopLayer(float? fadeOverride = null);
        bool IsBlocking { get; }
        void InjectSpeed(float speed);
    }
}