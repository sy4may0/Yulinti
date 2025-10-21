using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IMoveState {
        int LayerIndex { get; }
        void Enter(StateRuntimePayload payload);
        void Exit(StateRuntimePayload payload);
        MovePlan Tick(StateRuntimePayload payload);
        IMoveState TryTransition(StateRuntimePayload payload);
    }

    public interface IAnimationPlan {
        void Play();
        void Stop(Action onCompleted = null);
        void StopLayer(float? fadeOverride = null);
        bool IsBlocking { get; }
    }

    public interface IAnimationSpeedInjectable {
        void InjectSpeed(float speed);
    }
}
