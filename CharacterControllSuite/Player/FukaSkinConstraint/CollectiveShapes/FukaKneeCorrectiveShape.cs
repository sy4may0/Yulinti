using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    public sealed class FukaKneeCorrectiveShape : IFukaCorrectiveShape
    {
        private SkinnedMeshRenderer _mesh;
        private float _angleSource;
        private string _90BlendShapeName;
        private string _150BlendShapeName;
        private string _120OffsetBlendShapeName;

        public FukaKneeCorrectiveShape(
            SkinnedMeshRenderer mesh,
            string blendShape90Name,
            string blendShape150Name,
            string blendShape120OffsetName
        )
        {
            _mesh = mesh;
            _90BlendShapeName = blendShape90Name;
            _150BlendShapeName = blendShape150Name;
            _120OffsetBlendShapeName = blendShape120OffsetName;
        }

        public void SetAngleSource(float angle)
        {
            _angleSource = angle;
        }

        public void Apply()
        {
            float fixedAngle = 180f - _angleSource;
            float weight90 = FukaSkinConstraintUtils.AngleToTriWeight(fixedAngle, 0f, 90f, 160f);
            float weight150 = FukaSkinConstraintUtils.AngleToWeight(fixedAngle, 90f, 160f);
            float weight120Offset = FukaSkinConstraintUtils.AngleToTriWeight(fixedAngle, 90f, 120f, 160f);

            int bsKneeFix90Index = _mesh.sharedMesh.GetBlendShapeIndex(_90BlendShapeName);
            int bsKneeFix150Index = _mesh.sharedMesh.GetBlendShapeIndex(_150BlendShapeName);
            int bsKneeFix120OffsetIndex = _mesh.sharedMesh.GetBlendShapeIndex(_120OffsetBlendShapeName);

            if (bsKneeFix90Index >= 0) _mesh.SetBlendShapeWeight(bsKneeFix90Index, weight90);
            if (bsKneeFix150Index >= 0) _mesh.SetBlendShapeWeight(bsKneeFix150Index, weight150);
            if (bsKneeFix120OffsetIndex >= 0) _mesh.SetBlendShapeWeight(bsKneeFix120OffsetIndex, weight120Offset);
        }

    }
}