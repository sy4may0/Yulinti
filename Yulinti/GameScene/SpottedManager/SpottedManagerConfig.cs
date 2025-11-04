using UnityEngine;

namespace Yulinti.SpottedManager {
    [System.Serializable]
    public sealed class SpottedManagerConfig {
        [Header("SpottableColliderRegistry/SpottableColliderの登録先")]
        [SerializeField] private headCollider _headCollider;
        [SerializeField] private breastCollider _breastCollider;
        [SerializeField] private hipFrontCollider _hipFrontCollider;
        [SerializeField] private hipBackCollider _hipBackCollider;

        [Header("RayCast/RayCast設定")]
        [SerializeField] private float _rayCastRadiusScale = 0.8f;
        [SerializeField] private float _rayCastMaxAngleDeg = 8f;

        public headCollider HeadCollider => _headCollider;
        public breastCollider BreastCollider => _breastCollider;
        public hipFrontCollider HipFrontCollider => _hipFrontCollider;
        public hipBackCollider HipBackCollider => _hipBackCollider;

        public float RayCastRadiusScale => _rayCastRadiusScale;
        public float RayCastMaxAngleDeg => _rayCastMaxAngleDeg;
    }
}