using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioInputMotus")]
    public sealed class ConfiguratioInputMotus : ScriptableObject, IConfiguratioInputMotus {
        [Header("ConfiguratioInputMotus/ConfiguratioInputMotus設定")]
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public InputActionReference MoveInput => _moveInput;
        public InputActionReference SprintInput => _sprintInput;
        public InputActionReference CrouchInput => _crouchInput;
    }
}