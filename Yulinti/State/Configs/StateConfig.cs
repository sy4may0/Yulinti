using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class StateConfig {
        [Header("StateConfig/State設定")]
        [SerializeField] private BaseStateConfig _baseStateConfig;
        [SerializeField] private CrouchStateConfig _crouchStateConfig;

        public BaseStateConfig BaseStateConfig => _baseStateConfig;
        public CrouchStateConfig CrouchStateConfig => _crouchStateConfig;
    }
}