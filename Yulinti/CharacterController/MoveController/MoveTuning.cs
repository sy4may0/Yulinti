using UnityEngine;

namespace Yulinti.CharacterController
{
    [CreateAssetMenu(menuName = "Yulinti/MoveTuning")]
    public class MoveTuning : ScriptableObject
    {
        [Header("Move パラメータ")]
        [Tooltip("移動入力デッドゾーン（二乗値）")]
        public float MoveInputDeadZoneSq = 0.001f;
    
        [Tooltip("速度スムージング時間の上限")]
        public float MaxSmoothTime = 0.1f;
    
        [Tooltip("速度スムージング時間の下限")]
        public float MinSmoothTime = 0.05f;
    
        [Tooltip("回転スムージング時間")]
        public float RotationSmoothTime = 0.1f;
    
        [Tooltip("重力加速度(Grounder想定)")]
        public float Gravity = -20f;
    }
}