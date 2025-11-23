using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeLoci : IConfiguratioPuellaeLoci {
        [Header("ConfiguratioPuellaeLoci/CharacterController")]
        [SerializeField] private CharacterController _characterController;

        public NihilAut<CharacterController> CharacterController => new NihilAut<CharacterController>(_characterController);
    }
}
