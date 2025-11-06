using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerCrouchStateConfig {
        [Header("CrouchStateConfig/CrouchState設定")]
        [SerializeField] private PlayerCrouchIdleStateConfig _crouchIdleStateConfig;
        [SerializeField] private PlayerCrouchWalkStateConfig _crouchWalkStateConfig;
        [SerializeField] private PlayerCrouchAnimationConfig _crouchAnimationConfig;

        public PlayerCrouchIdleStateConfig CrouchIdleStateConfig => _crouchIdleStateConfig;
        public PlayerCrouchWalkStateConfig CrouchWalkStateConfig => _crouchWalkStateConfig;
        public PlayerCrouchAnimationConfig CrouchAnimationConfig => _crouchAnimationConfig;
    }
}