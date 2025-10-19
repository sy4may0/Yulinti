using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class IdleStateConfig {
        [Header("IdleState移動制御")]
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 30f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 20f;
    }
}