using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite
{
    [System.Serializable]
    public class MoveTuning
    {
        [Header("Move パラメータ")]
        [Tooltip("移動入力デッドゾーン（二乗値）")]
        public float MoveInputDeadZoneSq = 0.001f;
    
        [Tooltip("速度スムージング時間の上限")]
        public float MaxSmoothTime = 1.0f;
    
        [Tooltip("速度スムージング時間の下限")]
        public float MinSmoothTime = 0.05f;
    
        [Tooltip("回転スムージング時間")]
        public float RotationSmoothTime = 0.2f;
    
        [Tooltip("重力加速度(Grounder想定)")]
        public float Gravity = -20f;
    }
}