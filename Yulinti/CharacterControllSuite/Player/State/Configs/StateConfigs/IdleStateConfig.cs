using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class PlayerIdleStateConfig {
        [Header("IdleState移動制御")]
        [Tooltip("加速速度")]
        [SerializeField] private float _accelerationToTargetSpeed = 30f;
        [Tooltip("減速速度")]
        [SerializeField] private float _decelerationToTargetSpeed = 20f;

        public float AccelerationToTargetSpeed => _accelerationToTargetSpeed;
        public float DecelerationToTargetSpeed => _decelerationToTargetSpeed;
    }
}