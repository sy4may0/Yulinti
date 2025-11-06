using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerBaseStateConfig {
        [Header("BaseStateConfig/BaseState設定")]
        [SerializeField] private PlayerIdleStateConfig _idleStateConfig;
        [SerializeField] private PlayerWalkStateConfig _walkStateConfig;
        [SerializeField] private PlayerRunStateConfig _runStateConfig;
        [SerializeField] private PlayerBaseAnimationConfig _baseAnimationConfig;

        public PlayerIdleStateConfig IdleStateConfig => _idleStateConfig;
        public PlayerWalkStateConfig WalkStateConfig => _walkStateConfig;
        public PlayerRunStateConfig RunStateConfig => _runStateConfig;
        public PlayerBaseAnimationConfig BaseAnimationConfig => _baseAnimationConfig;
    }
}