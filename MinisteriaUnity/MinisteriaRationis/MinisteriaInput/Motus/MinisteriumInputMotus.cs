using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumInputMotus {
        private readonly InputActionReference _moveInput;
        private readonly InputActionReference _sprintInput;
        private readonly InputActionReference _crouchInput;

        public MinisteriumInputMotus(IConfiguratioInputMotus configuratioInputMotus) {
            _moveInput = configuratioInputMotus.MoveInput.EvolvareNuncium("MinisteriumInputMotus MoveInput is null.");
            _sprintInput = configuratioInputMotus.SprintInput.EvolvareNuncium("MinisteriumInputMotus SprintInput is null.");
            _crouchInput = configuratioInputMotus.CrouchInput.EvolvareNuncium("MinisteriumInputMotus CrouchInput is null.");
        }

        public Vector2 LegoMotus => _moveInput?.action?.enabled == true ? _moveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool LegoCursus => _sprintInput?.action?.enabled == true && _sprintInput.action.IsPressed();
        public bool LegoIncumbo => _crouchInput?.action?.enabled == true && _crouchInput.action.IsPressed();
    }
}