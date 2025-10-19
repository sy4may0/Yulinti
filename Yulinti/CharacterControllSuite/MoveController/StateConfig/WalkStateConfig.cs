using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class WalkStateConfig {
        [Header("WalkState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] public float BaseSpeed = 1.2f;
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 5f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 1f;
    }
}