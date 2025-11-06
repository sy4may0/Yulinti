using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerRunStateConfig {
        [Header("RunState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] private float _baseSpeed = 3.3f;
        [Tooltip("加速速度")]
        [SerializeField] private float _accelerationToTargetSpeed = 15;
        [Tooltip("減速速度")]
        [SerializeField] private float _decelerationToTargetSpeed = 15f;

        public float BaseSpeed => _baseSpeed;
        public float AccelerationToTargetSpeed => _accelerationToTargetSpeed;
        public float DecelerationToTargetSpeed => _decelerationToTargetSpeed;
    }
}