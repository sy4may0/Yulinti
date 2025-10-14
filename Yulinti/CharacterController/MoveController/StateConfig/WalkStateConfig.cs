using UnityEngine;

namespace Yulinti.CharacterController {
    [System.Serializable]
    public class WalkStateConfig {
        [Header("WalkState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] public float BaseSpeed = 1.0f;
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 14f;
    }
}