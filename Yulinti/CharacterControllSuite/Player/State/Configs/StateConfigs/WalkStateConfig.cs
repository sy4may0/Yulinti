using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerWalkStateConfig {
        [Header("WalkState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] private float _baseSpeed = 1.2f;
        [Tooltip("加速速度")]
        [SerializeField] private float _accelerationToTargetSpeed = 20;
        [Tooltip("減速速度")]
        [SerializeField] private float _decelerationToTargetSpeed = 10f;

        public float BaseSpeed => _baseSpeed;
        public float AccelerationToTargetSpeed => _accelerationToTargetSpeed;
        public float DecelerationToTargetSpeed => _decelerationToTargetSpeed;
    }
}