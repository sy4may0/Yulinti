using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraInput : IAnchora {
        InputActionReference MoveInput { get; }
        InputActionReference SprintInput { get; }
        InputActionReference CrouchInput { get; }
    }
}
