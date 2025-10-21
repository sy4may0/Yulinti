using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class RunStateConfig {
        [Header("RunState移動制御")]
        [Tooltip("基本速度")]
        [SerializeField] public float BaseSpeed = 3.3f;
        [Tooltip("加速速度")]
        [SerializeField] public float AccelerationToTargetSpeed = 20f;
        [Tooltip("減速速度")]
        [SerializeField] public float DecelerationToTargetSpeed = 15f;
    }
}