using UnityEngine;
using Yulinti.RayCastSuite;

namespace Yulinti.RayCastSuite {
    public enum RayCastDirection {
        Center,
        Dir0,
        Dir60,
        Dir120,
        Dir180,
        Dir240,
        Dir300,
    }

    public static class RayCastUtil {
        /// ヒットした位置が前方かどうかを判定する
        /// </summary>
        /// <param name="target">対象のTransform</param>
        /// <param name="hitPoint">ヒットした位置</param>
        /// <returns>前方にヒットしたかどうか</returns>
        public static bool IsHitInFront(
            Transform target,
            Vector3 hitPoint
        ) {
            Vector3 dirToHit = (hitPoint - target.position).normalized;
            float dot = Vector3.Dot(target.forward, dirToHit);

            return dot >= 0;
        }
    }

    public readonly struct RaycastDirections
    {
        public readonly Vector3 Center;
        public readonly Vector3 D0;
        public readonly Vector3 D60;
        public readonly Vector3 D120;
        public readonly Vector3 D180;
        public readonly Vector3 D240;
        public readonly Vector3 D300;
        public readonly bool IsAllCenter;
        public readonly Vector3 Origin;
    
        public RaycastDirections(
            Vector3 origin,
            Vector3 center,
            Vector3 d0, Vector3 d60, Vector3 d120, Vector3 d180, Vector3 d240, Vector3 d300,
            bool isAllCenter
        ){
            Origin = origin;
            Center = center;
            D0 = d0; D60 = d60; D120 = d120; D180 = d180; D240 = d240; D300 = d300;
            IsAllCenter = isAllCenter;
        }
    
        public Vector3 Get(RayCastDirection direction) => direction switch
        {
            RayCastDirection.Center => Center,
            RayCastDirection.Dir0   => D0,
            RayCastDirection.Dir60  => D60,
            RayCastDirection.Dir120 => D120,
            RayCastDirection.Dir180 => D180,
            RayCastDirection.Dir240 => D240,
            RayCastDirection.Dir300 => D300,
            _ => Center
        };
    
        public Vector3 GetOrigin() => Origin;
    
        /// <summary>
        /// 常に Center + 六角6方向を生成（LODは無視）。
        /// 半径は「Collider見かけ半径×radiusScale」と「角度上限maxAngleDeg」による距離依存上限の小さい方。
        /// </summary>
        public static RaycastDirections Create(
            Vector3 origin,
            Transform target,
            float radiusScale = 0.8f,
            float maxAngleDeg = 8f
        )
        {
            Vector3 toTarget = target.position - origin;
            float dist = Mathf.Max(1e-6f, toTarget.magnitude);
            Vector3 forward = toTarget / dist;
    
            // forward に直交する基底
            Vector3 arbitraryUp =
                Mathf.Abs(Vector3.Dot(forward, Vector3.up)) > 0.99f ? Vector3.right : Vector3.up;
            Vector3 right = Vector3.Normalize(Vector3.Cross(arbitraryUp, forward));
            Vector3 up    = Vector3.Cross(forward, right); // 既に正規直交。再正規化不要
    
            // オフセット半径（距離で角度上限をかけて“外し感”抑制）
            float targetRadius = EstimateTargetRadius(target);
            float maxShift = dist * Mathf.Tan(maxAngleDeg * Mathf.Deg2Rad);
            float r = Mathf.Min(targetRadius * Mathf.Max(0f, radiusScale), maxShift);
    
            // ほぼオフセット不要なら全部 Center で埋める（分岐・計算コスト最小化）
            if (r <= 1e-5f)
            {
                return new RaycastDirections(
                    origin, forward, forward, forward, forward, forward, forward, forward,
                    true
                );
            }
    
            // 60°系の cos/sin を定数で（三角関数コールなし）
            const float C = 0.5f;               // cos(60°)
            const float S = 0.866025403784f;    // sin(60°)
    
            // 単位円上 6 頂点: (1,0),(C,S),(-C,S),(-1,0),(-C,-S),(C,-S)
            Vector3 d0   = Compute(forward, right, up, r, +1f,  0f);
            Vector3 d60  = Compute(forward, right, up, r, +C,  +S);
            Vector3 d120 = Compute(forward, right, up, r, -C,  +S);
            Vector3 d180 = Compute(forward, right, up, r, -1f,  0f);
            Vector3 d240 = Compute(forward, right, up, r, -C,  -S);
            Vector3 d300 = Compute(forward, right, up, r, +C,  -S);
    
            return new RaycastDirections(origin, forward, d0, d60, d120, d180, d240, d300, false);
    
            // ローカル: (ux,uy) は単位円座標
            static Vector3 Compute(Vector3 fwd, Vector3 right, Vector3 up, float radius, float ux, float uy)
            {
                Vector3 offset = right * (ux * radius) + up * (uy * radius);
                return (fwd + offset).normalized;
            }
        }
    
        // スケール込みで“見かけ半径”を概算（どのColliderでもそれなりに機能）
        private static float EstimateTargetRadius(Transform target)
        {
            if (target.TryGetComponent<Collider>(out var col))
            {
                var e = col.bounds.extents;
                return Mathf.Max(e.x, e.y, e.z);
            }
            return 0.25f;
        }
    }
 }