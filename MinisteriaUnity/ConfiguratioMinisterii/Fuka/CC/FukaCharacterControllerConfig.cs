using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class FukaCharacterControllerConfig : IFukaCharacterControllerConfig {
        [Header("FukaCharacterControllerConfig/CharacterController")]
        [SerializeField] private CharacterController _characterController;

        public CharacterController CharacterController => _characterController;
    }
}
