using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharactorControlUtils {
    public struct MoveOutput {
        public float DesiredSpeed;
        public Quaternion DesiredDirection;
        public float SpeedSmoothTime;
    }

    public interface IMoveState {
        void Enter(MoveContext context);
        void Exit(MoveContext context);
        MoveOutput Tick(MoveContext context, float deltaTime);
        IMoveState TryTransition(MoveContext context);
    }
    
    /// <summary>
    /// キャラクター駆動統合コンテキスト
    /// キャラクター駆動の各種データを管理する
    /// <param name="characterController">キャラクターコントローラー</param>
    /// <param name="Camera">カメラ</param>
    /// <param name="CurrentSpeed">現在の速度 / コントローラーに適用するタイミングで更新すること。</param>
    /// <param name="CurrentYaw">現在のYaw / コントローラーに適用するタイミングで更新すること。</param>
    /// <param name="SpeedVelRef">速度のSmoothDampの参照用変数 / これはSmoothDampの参照用で、変更禁止。</param>
    /// <param name="RotationVelRef">回転のSmoothDampの参照用変数 / これはSmoothDampの参照用で、変更禁止。</param>
    /// <param name="RotationSmoothTime">回転の固定スムージング時間</param>
    /// <param name="MoveInputDeadZoneSq">移動入力デッドゾーンの二乗 / Start()とかAwake()とかでMoveConfigのMoveInputDeadZoneを二乗して代入しておくこと。</param>
    /// <param name="IsGlounded">接地判定 / コントローラーに適用するタイミングで更新すること。</param>
    /// <param name="Config">移動設定</param>
    /// <param name="CharactorControlUtils">キャラクター駆動統合ユーティリティ</param>
    /// </summary>
    public class MoveContext {
        public CharacterController characterController;
        public Camera Camera;
        public float CurrentSpeed;
        public float CurrentYaw;
        public float SpeedVelRef;
        public float RotationVelRef;
        public float RotationSmoothTime;
        public float IsGlounded;
        public float MaxSmoothTime;
        public float MinSmoothTime;
        public float MoveInputDeadZoneSq;
        public MoveConfig Config;
        public CharactorControlUtils CharactorControlUtils;
    }

    [System.Serializable]
    public class MoveConfig {
        [SerializeField]
        public float MoveInputDeadZone = 0.0001f;

        [Header("入力設定")]
        [SerializeField]
        [Tooltip("移動入力(Vector2)")]
        public InputActionReference MoveInput;
        [Tooltip("スプリント入力(Bool)")]
        public InputActionReference SprintInput;
    }
}