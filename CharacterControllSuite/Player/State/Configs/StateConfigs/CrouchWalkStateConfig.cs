using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerCrouchWalkStateConfig {
        [Header("CrouchWalkState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] private float _baseSpeed = 0.9f;
        [Tooltip("加速速度")]
        [SerializeField] private float _accelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] private float _decelerationToTargetSpeed = 20f;

        public float BaseSpeed => _baseSpeed;
        public float AccelerationToTargetSpeed => _accelerationToTargetSpeed;
        public float DecelerationToTargetSpeed => _decelerationToTargetSpeed;
    }
}