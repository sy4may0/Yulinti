using UnityEngine.InputSystem;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioInputMotus {
        InputActionReference MoveInput { get; }
        InputActionReference SprintInput { get; }
        InputActionReference CrouchInput { get; }
    }
}