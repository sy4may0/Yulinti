using UnityEngine;
using RootMotion.FinalIK;
using Yulinti.CharacterControllSuite;
using System.Text;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public class GrounderController {
        [Header("GrounderSettings/FinalIKのGrounder設定")]
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
        

        public void AutoLink() {
            if (_grounder != null && _grounder.ik == null && _fullBodyIK != null) {
                _grounder.ik = _fullBodyIK;
            }
        }

        public void Update() {
            _fullBodyIK?.solver.Update();
        }

        public void Disable() {
            _fullBodyIK.enabled = false;
        }

        public void ForceLegAboveGround()
        {
            float leftOffset = GetFootOffsetFromGround(_leftFoot.position, _leftToe.position, Vector3.up);
            float rightOffset = GetFootOffsetFromGround(_rightFoot.position, _rightToe.position, Vector3.up);
            float rootOffset = Mathf.Max(leftOffset, rightOffset);
            _root.position = _root.position + Vector3.up * rootOffset;
        
        }
        
        private float GetFootOffsetFromGround(
            Vector3 footPos, Vector3 toePos, Vector3 characterUp) // characterUp=transform.upで可
        {
            // foot と toe の“上下”関係（Up軸に沿った符号付き差）
            float dy = Vector3.Dot(footPos - toePos, characterUp);
        
            // Ray の起点（foot 補正時 or toe 補正時で打ち分け）
            Vector3 rayOrigin = (dy < 0f)
                ? footPos + characterUp * _castHeight   // foot が toe より下 → foot から打つ（foot補正）
                : toePos + characterUp * _castHeight;  // foot が toe より上 → toe から打つ（toe補正）
        
            float groundY = float.NegativeInfinity;
            if (Physics.Raycast(rayOrigin, -characterUp, out var hit, _castHeight + _castDistance, _castLayer))
                groundY = hit.point.y + _epsilon;
        
            float currentY = footPos.y;
        
            if (dy < 0f)
            {
                // --- foot補正 ---
                // 地面＆foot 最低高さの双方を尊重、かつ“上方向にしか動かさない”
                float minFootY = _footYCorrection;
                float targetY = currentY;
        
                if (!float.IsNegativeInfinity(groundY))
                    targetY = Mathf.Max(targetY, groundY);
        
                targetY = Mathf.Max(targetY, minFootY);
        
                return targetY - currentY;
            }
            else
            {
                // --- toe補正 ---
                // toe の最低高さも維持しつつ、toe↔foot の Up差(dy) を保った foot の高さを計算
                float minToeY = _toeYCorrection;
                float minFootY = _footYCorrection;
        
                // toe の疑似ターゲットY（toe自体はここでは動かさないが制約として使う）
                float targetToeY = toePos.y;
        
                if (!float.IsNegativeInfinity(groundY))
                    targetToeY = Mathf.Max(targetToeY, groundY);  // toe接地点が地面下に落ちない
        
                targetToeY = Mathf.Max(targetToeY, minToeY);      // toe ≥ _toeYCorrection
        
                // foot は「toe のターゲット + dy」を基準に、地面＆foot 最低高さも満たす
                float baseFootY = targetToeY + dy;
        
                float targetFootY = currentY;                     // “下げない”ガード
                targetFootY = Mathf.Max(targetFootY, baseFootY);  // toe との相対差を維持
        
                if (!float.IsNegativeInfinity(groundY))
                    targetFootY = Mathf.Max(targetFootY, groundY);
        
                targetFootY = Mathf.Max(targetFootY, minFootY);   // foot ≥ _footYCorrection
        
                return targetFootY - currentY;
            }
        }
    }
}