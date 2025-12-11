using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using UnityEngine.InputSystem;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumInputMotus {
        private readonly InputActionReference _moveInput;
        private readonly InputActionReference _sprintInput;
        private readonly InputActionReference _crouchInput;

        public MinisteriumInputMotus(IAnchoraInput anchoraInput) {
            _moveInput = anchoraInput.MoveInput;
            _sprintInput = anchoraInput.SprintInput;
            _crouchInput = anchoraInput.CrouchInput;
        }

        public Vector2 LegoMotus => _moveInput?.action?.enabled == true ? _moveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool LegoCursus => _sprintInput?.action?.enabled == true && _sprintInput.action.IsPressed();
        public bool LegoIncumbo => _crouchInput?.action?.enabled == true && _crouchInput.action.IsPressed();
    }

}



