using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class BaseStateConfig {
        [Header("BaseStateConfig/BaseState設定")]
        [SerializeField] private IdleStateConfig _idleStateConfig;
        [SerializeField] private WalkStateConfig _walkStateConfig;
        [SerializeField] private RunStateConfig _runStateConfig;
        [Space(12)]
        [SerializeField] private BaseAnimationConfig _baseAnimationConfig;
        [Space(18)]

        public IdleStateConfig IdleStateConfig => _idleStateConfig;
        public WalkStateConfig WalkStateConfig => _walkStateConfig;
        public RunStateConfig RunStateConfig => _runStateConfig;
        public BaseAnimationConfig BaseAnimationConfig => _baseAnimationConfig;
    }
}