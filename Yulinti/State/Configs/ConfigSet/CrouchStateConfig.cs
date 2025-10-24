using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class CrouchStateConfig {
        [Header("CrouchStateConfig/CrouchState設定")]
        [SerializeField] private CrouchIdleStateConfig _crouchIdleStateConfig;
        [SerializeField] private CrouchWalkStateConfig _crouchWalkStateConfig;
        [Space(12)]
        [SerializeField] private CrouchAnimationConfig _crouchAnimationConfig;
        [Space(18)]

        public CrouchIdleStateConfig CrouchIdleStateConfig => _crouchIdleStateConfig;
        public CrouchWalkStateConfig CrouchWalkStateConfig => _crouchWalkStateConfig;
        public CrouchAnimationConfig CrouchAnimationConfig => _crouchAnimationConfig;
    }
}