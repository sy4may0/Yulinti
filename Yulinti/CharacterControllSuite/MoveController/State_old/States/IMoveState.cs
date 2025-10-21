using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IMoveState {
        int LayerIndex { get; }
        void Enter(MoveRuntime runtime);
        void Exit(MoveRuntime runtime);
        MovePlan Tick(MoveRuntime runtime, float deltaTime);
        IMoveState TryTransition(MoveRuntime runtime);
        IAnimationPlan GetAnimationPlan();
    }
}
