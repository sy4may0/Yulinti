using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.Officia.Contractus {
    public interface IAnchoraInput : IAnchora {
        // // Motus ////
        InputActionReference MoveInput { get; }
        InputActionReference SprintInput { get; }
        InputActionReference CrouchInput { get; }

        // // Velum ////
        InputActionReference ClickInput { get; }
        InputActionReference ClickRightInput { get; }
        InputActionReference SubmitInput { get; }
        InputActionReference CancelInput { get; }
        InputActionReference NavigateInput { get; }

        // // Action ////
        InputActionReference SpectaculumCorporisInput { get; }
    }
}
