using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class StateConfig {
        [Header("StateConfig/State設定")]
        [Tooltip("IdleState設定")]
        [SerializeField] private IdleStateConfig _idleStateConfig;
        [Tooltip("WalkState設定")]
        [SerializeField] private WalkStateConfig _walkStateConfig;
        [Tooltip("RunState設定")]
        [SerializeField] private RunStateConfig _runStateConfig;
        [Tooltip("CrouchIdleState設定")]
        [SerializeField] private CrouchIdleStateConfig _crouchIdleStateConfig;
        [Tooltip("CrouchWalkState設定")]
        [SerializeField] private CrouchWalkStateConfig _crouchWalkStateConfig;

        [Header("AnimationConfig/アニメーション設定")]
        [Tooltip("BaseAnimation設定")]
        [SerializeField] private BaseAnimationConfig _baseAnimationConfig;
        [Tooltip("CrouchAnimation設定")]
        [SerializeField] private CrouchAnimationConfig _crouchAnimationConfig;    

        public IdleStateConfig IdleStateConfig => _idleStateConfig;
        public WalkStateConfig WalkStateConfig => _walkStateConfig;
        public RunStateConfig RunStateConfig => _runStateConfig;
        public CrouchIdleStateConfig CrouchIdleStateConfig => _crouchIdleStateConfig;
        public CrouchWalkStateConfig CrouchWalkStateConfig => _crouchWalkStateConfig;
        public BaseAnimationConfig BaseAnimationConfig => _baseAnimationConfig;
        public CrouchAnimationConfig CrouchAnimationConfig => _crouchAnimationConfig;
    }