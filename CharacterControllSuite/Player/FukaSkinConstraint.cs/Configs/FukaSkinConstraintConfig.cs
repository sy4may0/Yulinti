using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public sealed class FukaSkinConstraintConfig {
        [Header("FukaSkinConstraints/Fukaスキン制約")]
        [Tooltip("リグRoot")]
        [SerializeField] private Transform _rigRoot;
        [Tooltip("右膝メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _rightLegMesh;
        [Tooltip("左膝メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _leftLegMesh;
        [Tooltip("腰メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _hipsMesh;
        [Tooltip("左腕メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _leftArmMesh;
        [Tooltip("右腕メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _rightArmMesh;

        [Tooltip("腰コレクティブシェイプ設定")]
        [SerializeField] private FukaHipsCorrectiveShapeConfig _hipsCorrectiveShapeConfig;
        [Tooltip("ひざコレクティブシェイプ設定")]
        [SerializeField] private FukaKneeCorrectiveShapeConfig _kneeCorrectiveShapeConfig;

        public Transform RigRoot => _rigRoot;
        public SkinnedMeshRenderer RightLegMesh => _rightLegMesh;
        public SkinnedMeshRenderer LeftLegMesh => _leftLegMesh;
        public SkinnedMeshRenderer HipsMesh => _hipsMesh;
        public SkinnedMeshRenderer LeftArmMesh => _leftArmMesh;
        public SkinnedMeshRenderer RightArmMesh => _rightArmMesh;

        public FukaHipsCorrectiveShapeConfig HipsCorrectiveShapeConfig => _hipsCorrectiveShapeConfig;
        public FukaKneeCorrectiveShapeConfig KneeCorrectiveShapeConfig => _kneeCorrectiveShapeConfig;

    }
}