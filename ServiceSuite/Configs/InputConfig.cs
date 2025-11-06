using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.ServiceSuite {
    [System.Serializable]
    public class InputConfig {
        [Header("InputConfig/Input設定")]
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public InputActionReference MoveInput => _moveInput;
        public InputActionReference SprintInput => _sprintInput;
        public InputActionReference CrouchInput => _crouchInput;
    }
}