using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaGrounderConfig : IFukaGrounderConfig {
        [Header("FukaGrounderConfig/足設定")]
        [SerializeField] private Transform _leftFoot;
        [SerializeField] private Transform _leftToe;
        [SerializeField] private Transform _rightFoot;
        [SerializeField] private Transform _rightToe;

        [Header("FukaGrounderConfig/Root(Hips)設定")]
        [SerializeField] private Transform _root;

        [Header("FukaGrounderConfig/足補正設定")]
        [SerializeField] private float _toeYCorrection = 0.034f;
        [SerializeField] private float _footYCorrection = 0.113f;
 

        [Header("FukaGrounderConfig/地面キャスト設定")]
        [SerializeField] private float _castHeight = 1.0f;
        [SerializeField] private float _castDistance = 1.0f;
        [SerializeField] private LayerMask _castLayer;
        [SerializeField] private float _epsilon = 0.001f;

        public Transform LeftFoot => _leftFoot;
        public Transform LeftToe => _leftToe;
        public Transform RightFoot => _rightFoot;
        public Transform RightToe => _rightToe;
        public Transform Root => _root;
        public float ToeYCorrection => _toeYCorrection;
        public float FootYCorrection => _footYCorrection;
        public float CastHeight => _castHeight;
        public float CastDistance => _castDistance;
        public LayerMask CastLayer => _castLayer;
        public float Epsilon => _epsilon;
   }
}