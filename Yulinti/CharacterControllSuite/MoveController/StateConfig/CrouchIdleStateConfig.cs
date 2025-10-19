using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class CrouchIdleStateConfig {
        [Header("CrouchIdleState移動制御")]
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 10f;
    }
}