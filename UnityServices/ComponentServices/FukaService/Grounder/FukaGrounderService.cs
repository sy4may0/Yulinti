using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaGrounderService : IServiceLateTickable {
        private readonly IFukaGrounderConfig _config;
        public FukaGrounderService(IFukaGrounderConfig config) {
            _config = config;
        }

        private float GetToeOffset(
            Transform foot, Transform toe, Vector3 CharacterUp,
            float groundY, float currentY, float dy
        ) {
                // --- toe補正 ---
                float minToeY = _config.ToeYCorrection;
                float minFootY = _config.FootYCorrection;
                float targetToeY = toe.position.y;
                if (!float.IsNegativeInfinity(groundY)) {
                    targetToeY = Mathf.Max(targetToeY, groundY + minToeY);
                }
                float baseFootY = targetToeY + dy;
                float targetFootY = currentY;
                targetFootY = Mathf.Max(targetFootY, baseFootY);
                if (!float.IsNegativeInfinity(groundY)) {
                    targetFootY = Mathf.Max(targetFootY, groundY + minFootY);
                }
                return targetFootY - currentY;
        }

        private float GetFootOffset(
            Transform foot, Transform toe, Vector3 CharacterUp,
            float groundY, float currentY
        ) {
            float minFootY = _config.FootYCorrection;
            float targetY = currentY;
            if (!float.IsNegativeInfinity(groundY)) {
                targetY = Mathf.Max(targetY, groundY + minFootY);
            }
            return targetY - currentY;
         
        }

        private float GetGroundY(Vector3 origin, Vector3 direction, float distance, LayerMask layer) {
            if (Physics.Raycast(origin, direction, out var hit, distance, layer)) {
                return hit.point.y + _config.Epsilon;
            }
            return float.NegativeInfinity;
        }

        private float GetFootOffsetFromGround(Transform foot, Transform toe, Vector3 CharacterUp) {
            if (foot == null) {
                return 0f;
            }

            if (toe == null) {
                Vector3 rayOrigin = foot.position + CharacterUp * _config.CastHeight;
                float groundY = GetGroundY(rayOrigin, -CharacterUp, _config.CastHeight + _config.CastDistance, _config.CastLayer);
                float currentY = foot.position.y;
                return GetFootOffset(foot, toe, CharacterUp, groundY, currentY);

            } else {

                float dy = Vector3.Dot(foot.position - toe.position, CharacterUp);
                Vector3 rayOrigin = (dy < 0f) 
                    ? foot.position + CharacterUp * _config.CastHeight
                    : toe.position + CharacterUp * _config.CastHeight;

                float groundY = GetGroundY(rayOrigin, -CharacterUp, _config.CastHeight + _config.CastDistance, _config.CastLayer);
                float currentY = foot.position.y;

                if (dy < 0f) {
                    return GetFootOffset(foot, toe, CharacterUp, groundY, currentY);
                } else {
                    return GetToeOffset(foot, toe, CharacterUp, groundY, currentY, dy);
                }
            }
        }

        public float GetRootOffset() {
            float leftOffset = GetFootOffsetFromGround(_config.LeftFoot, _config.LeftToe, Vector3.up);
            float rightOffset = GetFootOffsetFromGround(_config.RightFoot, _config.RightToe, Vector3.up);
            return Mathf.Max(leftOffset, rightOffset);
        }

        public void ApplyRootOffset(float offset) {
            _config.Root.position = _config.Root.position + Vector3.up * offset;
        }

        public void LateTick(float deltaTime) {
            ApplyRootOffset(GetRootOffset());
        }
    }
}