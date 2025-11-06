using UnityEngine;
using RootMotion.FinalIK;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public sealed class GrounderController {
        private readonly GrounderConfig _config;

        public GrounderController(GrounderConfig config) {
            _config = config;
        }

        public void Update() {
            _config.FullBodyIK?.solver.Update();
        }

        public void Disable() {
            _config.FullBodyIK.enabled = false;
        }

        public void ForceLegAboveGround()
        {
            float leftOffset = GetFootOffsetFromGround(_config.LeftFoot.position, _config.LeftToe.position, Vector3.up);
            float rightOffset = GetFootOffsetFromGround(_config.RightFoot.position, _config.RightToe.position, Vector3.up);
            float rootOffset = Mathf.Max(leftOffset, rightOffset);
            _config.Root.position = _config.Root.position + Vector3.up * rootOffset;
        
        }
        
        private float GetFootOffsetFromGround(
            Vector3 footPos, Vector3 toePos, Vector3 characterUp) // characterUp=transform.upで可
        {
            // foot と toe の"上下"関係（Up軸に沿った符号付き差）
            float dy = Vector3.Dot(footPos - toePos, characterUp);
        
            // Ray の起点（foot 補正時 or toe 補正時で打ち分け）
            Vector3 rayOrigin = (dy < 0f)
                ? footPos + characterUp * _config.CastHeight   // foot が toe より下 → foot から打つ（foot補正）
                : toePos + characterUp * _config.CastHeight;  // foot が toe より上 → toe から打つ（toe補正）
        
            float groundY = float.NegativeInfinity;
            if (Physics.Raycast(rayOrigin, -characterUp, out var hit, _config.CastHeight + _config.CastDistance, _config.CastLayer))
                groundY = hit.point.y + _config.Epsilon;
        
            float currentY = footPos.y;
        
            if (dy < 0f)
            {
                // --- foot補正 ---
                // 地面＆foot 最低高さの双方を尊重、かつ"上方向にしか動かさない"
                float minFootY = _config.FootYCorrection;
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
                float minToeY = _config.ToeYCorrection;
                float minFootY = _config.FootYCorrection;
        
                // toe の疑似ターゲットY（toe自体はここでは動かさないが制約として使う）
                float targetToeY = toePos.y;
        
                if (!float.IsNegativeInfinity(groundY))
                    targetToeY = Mathf.Max(targetToeY, groundY);  // toe接地点が地面下に落ちない
        
                targetToeY = Mathf.Max(targetToeY, minToeY);      // toe ≥ _toeYCorrection
        
                // foot は「toe のターゲット + dy」を基準に、地面＆foot 最低高さも満たす
                float baseFootY = targetToeY + dy;
        
                float targetFootY = currentY;                     // "下げない"ガード
                targetFootY = Mathf.Max(targetFootY, baseFootY);  // toe との相対差を維持
        
                if (!float.IsNegativeInfinity(groundY))
                    targetFootY = Mathf.Max(targetFootY, groundY);
        
                targetFootY = Mathf.Max(targetFootY, minFootY);   // foot ≥ _footYCorrection
        
                return targetFootY - currentY;
            }
        }
    }
}