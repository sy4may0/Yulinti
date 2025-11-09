using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class MoveInputConfig : IMoveInputConfig {
        [Header("MoveInputConfig/MoveInput設定")]
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public InputActionReference MoveInput => _moveInput;
        public InputActionReference SprintInput => _sprintInput;
        public InputActionReference CrouchInput => _crouchInput;
    }
}