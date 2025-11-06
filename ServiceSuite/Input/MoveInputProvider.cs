using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.CharacterControllSuite;

namespace Yulinti.ServiceSuite
{
    [System.Serializable]
    public sealed class MoveInputProvider
    {
        private readonly InputConfig _inputConfig;

        public MoveInputProvider(InputConfig inputConfig) {
            _inputConfig = inputConfig;
        }

        public Vector2 Move  => _inputConfig.MoveInput?.action?.enabled  == true ? _inputConfig.MoveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool   Sprint => _inputConfig.SprintInput?.action?.enabled == true && _inputConfig.SprintInput.action.IsPressed();
        public bool   Crouch => _inputConfig.CrouchInput?.action?.enabled == true && _inputConfig.CrouchInput.action.IsPressed();
    }
}