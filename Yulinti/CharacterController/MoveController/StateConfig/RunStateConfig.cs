using UnityEngine;

namespace Yulinti.CharacterController {
    [System.Serializable]
    public class RunStateConfig {
        [Header("RunState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] public float BaseSpeed = 1.5f;
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 10f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 14f;
    }
}