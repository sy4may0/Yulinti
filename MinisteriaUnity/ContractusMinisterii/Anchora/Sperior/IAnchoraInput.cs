using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraInput : IAnchora {
        InputActionReference MoveInput { get; }
        InputActionReference SprintInput { get; }
        InputActionReference CrouchInput { get; }
        InputActionReference ClickInput { get; }
        InputActionReference ClickRightInput { get; }
        InputActionReference SubmitInput { get; }
        InputActionReference CancelInput { get; }
        InputActionReference NavigateInput { get; }
    }
}
