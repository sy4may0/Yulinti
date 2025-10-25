using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class StateConfig {
        [Header("StateConfig/State設定")]
        [SerializeField] private BaseStateConfig _baseStateConfig;
        [SerializeField] private CrouchStateConfig _crouchStateConfig;

        public BaseStateConfig BaseStateConfig => _baseStateConfig;
        public CrouchStateConfig CrouchStateConfig => _crouchStateConfig;
    }

    [System.Serializable]
    public class StateConfigCommon {
        [Header("StateConfigCommon/全体設定")]
        [Tooltip("移動入力デッドゾーン（二乗値）")]
        [SerializeField] private float _moveInputDeadZoneSq = 0.001f;
        [Tooltip("速度スムージング時間の上限")]
        [SerializeField] private float _maxSmoothTime = 1.0f;
        [Tooltip("速度スムージング時間の下限")]
        [SerializeField] private float _minSmoothTime = 0.05f;
        [Tooltip("回転スムージング時間")]
        [SerializeField] private float _rotationSmoothTime = 0.2f;
        [Tooltip("重力加速度(Grounder想定)")]
        [SerializeField] private float _gravity = -20f;

        public float MoveInputDeadZoneSq => _moveInputDeadZoneSq;
        public float MinSmoothTime => _minSmoothTime;
        public float MaxSmoothTime => _maxSmoothTime;
        public float RotationSmoothTime => _rotationSmoothTime;
        public float Gravity => _gravity;
    }
}