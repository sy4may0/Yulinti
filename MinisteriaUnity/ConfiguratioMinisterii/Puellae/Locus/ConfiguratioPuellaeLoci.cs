using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeLoci : IConfiguratioPuellaeLoci {
        [Header("ConfiguratioPuellaeLoci/CharacterController")]
        [SerializeField] private CharacterController _characterController;

        public CharacterController CharacterController => _characterController;
    }
}
