using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite
{
    [System.Serializable]
    public class MoveTuning
    {
        [Header("Move パラメータ")]
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
        public float MaxSmoothTime => _maxSmoothTime;
        public float MinSmoothTime => _minSmoothTime;
        public float RotationSmoothTime => _rotationSmoothTime;
        public float Gravity => _gravity;
    }
}