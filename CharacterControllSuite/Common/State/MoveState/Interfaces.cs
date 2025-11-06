using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IMoveState {
        int LayerIndex { get; }
        void Enter(MoveRuntimeReadOnly moveRuntimeRO);
        void Exit(MoveRuntimeReadOnly moveRuntimeRO);
        MovePlan Tick(MoveRuntimeReadOnly moveRuntimeRO);
        StateID TryTransition(MoveRuntimeReadOnly moveRuntimeRO);
    }
}