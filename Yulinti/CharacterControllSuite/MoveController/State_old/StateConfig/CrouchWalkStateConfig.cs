using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class CrouchWalkStateConfig {
        [Header("CrouchWalkState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] public float BaseSpeed = 0.5f;
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 10f;
    }
}