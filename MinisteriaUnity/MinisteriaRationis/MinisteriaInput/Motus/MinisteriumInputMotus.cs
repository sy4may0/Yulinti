using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumInputMotus {
        private readonly InputActionReference _moveInput;
        private readonly InputActionReference _sprintInput;
        private readonly InputActionReference _crouchInput;

        public MinisteriumInputMotus(IConfiguratioInputMotus configuratioInputMotus) {
            _moveInput = configuratioInputMotus.MoveInput.Evolvo(IDErrorum.MINISTERIUMINPUTMOTUS_MOVE_INPUT_NULL);
            _sprintInput = configuratioInputMotus.SprintInput.Evolvo(IDErrorum.MINISTERIUMINPUTMOTUS_SPRINT_INPUT_NULL);
            _crouchInput = configuratioInputMotus.CrouchInput.Evolvo(IDErrorum.MINISTERIUMINPUTMOTUS_CROUCH_INPUT_NULL);
        }

        public Vector2 LegoMotus => _moveInput?.action?.enabled == true ? _moveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool LegoCursus => _sprintInput?.action?.enabled == true && _sprintInput.action.IsPressed();
        public bool LegoIncumbo => _crouchInput?.action?.enabled == true && _crouchInput.action.IsPressed();
    }
}
