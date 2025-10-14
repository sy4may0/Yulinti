using UnityEngine;

namespace Yulinti.CharacterController {
    public interface IMoveState {
        void Enter(MoveRuntime runtime);
        void Exit(MoveRuntime runtime);
        MovePlan Tick(MoveRuntime runtime, float deltaTime);
        IMoveState TryTransition(MoveRuntime runtime);
    }
}
