using UnityEngine.InputSystem;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioInputMotus {
        NihilAut<InputActionReference> MoveInput { get; }
        NihilAut<InputActionReference> SprintInput { get; }
        NihilAut<InputActionReference> CrouchInput { get; }
    }
}
