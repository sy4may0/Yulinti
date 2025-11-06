using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerCrouchIdleStateConfig {
        [Header("CrouchIdleState移動制御")]
        [Tooltip("加速速度")]
        [SerializeField] private float _accelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] private float _decelerationToTargetSpeed = 10f;

        public float AccelerationToTargetSpeed => _accelerationToTargetSpeed;
        public float DecelerationToTargetSpeed => _decelerationToTargetSpeed;
    }
}