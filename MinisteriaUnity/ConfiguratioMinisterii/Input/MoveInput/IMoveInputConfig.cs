using UnityEngine.InputSystem;

namespace Yulinti.UnityServices.ServiceConfig {
    public interface IMoveInputConfig {
        InputActionReference MoveInput { get; }
        InputActionReference SprintInput { get; }
        InputActionReference CrouchInput { get; }
    }
}