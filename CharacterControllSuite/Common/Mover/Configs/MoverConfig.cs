using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class MoverConfig {
        [Header("MoverConfig/Mover設定")]
        [Tooltip("CharacterControllerコンポーネント")]
        [SerializeField] private CharacterController _characterController;

        public CharacterController CharacterController => _characterController;
    }
}