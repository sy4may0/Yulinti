using UnityEngine;
using RootMotion.FinalIK;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class GrounderConfig {
        [Header("MoverConfig/Grounder設定")]
        [Tooltip("FullBodyBipedIKコンポーネント")]
        [SerializeField] private FullBodyBipedIK _fullBodyIK;
        [Tooltip("GrounderFBBIKコンポーネント")]
        [SerializeField] private GrounderFBBIK _grounder;

        [Header("GrounderSetting/強制地面補正")]
        [Tooltip("左足のTransform")]
        [SerializeField] private Transform _leftFoot;
        [Tooltip("左足先端のTransform")]
        [SerializeField] private Transform _leftToe;
        [Tooltip("右足のTransform")]
        [SerializeField] private Transform _rightFoot;
        [Tooltip("右足先端のTransform")]
        [SerializeField] private Transform _rightToe;
        [Tooltip("Root(Hips)のTransform")]
        [SerializeField] private Transform _root;

        [Header("Ground Cast Setting/地面キャスト設定")]
        [Tooltip("キャスト高さ")]
        [SerializeField] private float _castHeight = 1.0f;
        [Tooltip("キャスト距離")]
        [SerializeField] private float _castDistance = 1.0f;
        [Tooltip("レイヤーマスク")]
        [SerializeField] private LayerMask _castLayer;
        [Tooltip("最小クリアランス")]
        [SerializeField] private float _epsilon = 0.001f;

        [Tooltip("ToeのY軸方向の補正量")]
        [SerializeField] private float _toeYCorrection = 0.034f;
        [Tooltip("FootのY軸方向の補正量")]
        [SerializeField] private float _footYCorrection = 0.113f;

        public FullBodyBipedIK FullBodyIK => _fullBodyIK;
        public GrounderFBBIK Grounder => _grounder;
        public Transform LeftFoot => _leftFoot;
        public Transform LeftToe => _leftToe;
        public Transform RightFoot => _rightFoot;
        public Transform RightToe => _rightToe;
        public Transform Root => _root;
        public float CastHeight => _castHeight;
        public float CastDistance => _castDistance;
        public LayerMask CastLayer => _castLayer;
        public float Epsilon => _epsilon;
        public float ToeYCorrection => _toeYCorrection;
        public float FootYCorrection => _footYCorrection;

    }
}