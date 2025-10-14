using UnityEngine;

namespace Yulinti.CharacterController {
    [System.Serializable]
    public class IdleStateConfig {
        [Header("IdleState移動制御")]
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed;
    }
}