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
    /// 
    /// "characterController": キャラクターコントローラー
    /// "MainCamera": カメラ / Stateでnullチェックしない。必ずAwake()で代入してnullチェックしておくこと。
    /// "MoveInput": 移動入力 / Stateでnullチェックしない。Update()で更新すること。
    /// "SprintInput": スプリント入力 / Stateでnullチェックしない。Update()で更新すること。
    /// "CurrentSpeed": 現在の速度 / コントローラーに適用するタイミングで更新すること。
    /// "CurrentYaw": 現在のYaw / コントローラーに適用するタイミングで更新すること。
    /// "SpeedVelRef": 速度のSmoothDampの参照用変数 / これはSmoothDampの参照用で、変更禁止。
    /// "RotationVelRef": 回転のSmoothDampの参照用変数 / これはSmoothDampの参照用で、変更禁止。
    /// "RotationSmoothTime": 回転の固定スムージング時間
    /// "MoveInputDeadZoneSq": 移動入力デッドゾーンの二乗 / Start()とかAwake()とかでMoveConfigのMoveInputDeadZoneを二乗して代入しておくこと。
    /// "IsGrounded": 接地判定 / コントローラーに適用するタイミングで更新すること。
    /// "CharactorControlUtils": キャラクター駆動統合ユーティリティ
    /// </summary>
    public class MoveContext {
        public CharacterController CharacterController;
        public Camera MainCamera;
        public Vector2 MoveAction;
        public bool SprintAction;
        public float CurrentSpeed;
        public float CurrentYaw;
        public float SpeedVelRef;
        public float RotationVelRef;
        public float RotationSmoothTime;
        public bool IsGrounded;
        public float MaxSmoothTime;
        public float MinSmoothTime;
        public float MoveInputDeadZoneSq;
        public CharactorControlUtils CharactorControlUtils;
    }

    [System.Serializable]
    public class MoveConfig {
        [Header("ターゲット")]

        [Tooltip("キャラクターコントローラー")]
        [SerializeField]
        public CharacterController CharacterController;
        [Tooltip("カメラ")]
        [SerializeField]
        public Camera MainCamera;

        [Header("入力設定")]

        [Tooltip("移動入力(Vector2)")]
        [SerializeField]
        public InputActionReference MoveInput;

        [Tooltip("スプリント入力(Bool)")]
        [SerializeField]
        public InputActionReference SprintInput;

        [Header("一般パラメータ")]
        [Tooltip("移動入力デッドゾーン")]
        [SerializeField]
        public float MoveInputDeadZone = 0.1f;
 
    }
}