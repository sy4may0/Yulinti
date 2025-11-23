using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioInputMotus")]
    public sealed class ConfiguratioInputMotus : ScriptableObject, IConfiguratioInputMotus {
        [Header("ConfiguratioInputMotus/ConfiguratioInputMotus設定")]
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public NihilAut<InputActionReference> MoveInput => new NihilAut<InputActionReference>(_moveInput);
        public NihilAut<InputActionReference> SprintInput => new NihilAut<InputActionReference>(_sprintInput);
        public NihilAut<InputActionReference> CrouchInput => new NihilAut<InputActionReference>(_crouchInput);
    }
}
