using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    public sealed class FukaKetsuCorrectiveShape : IFukaCorrectiveShape
    {
        private SkinnedMeshRenderer _mesh;
        private string _x150AnusBlendShapeName;
        private float _x150LeftAngleSource;
        private float _x150RightAngleSource;

        public FukaKetsuCorrectiveShape(
            SkinnedMeshRenderer mesh,
            string blendShapeX150AnusName
        )
        {
            _mesh = mesh;
            _x150AnusBlendShapeName = blendShapeX150AnusName;
        }

        public void SetX150LeftAngleSource(float angle)
        {
            _x150LeftAngleSource = angle;
        }
        public void SetX150RightAngleSource(float angle)
        {
            _x150RightAngleSource = angle;
        }

        public void Apply()
        {
            float weightX150Left = FukaSkinConstraintUtils.AngleToWeightReverse(_x150LeftAngleSource, 0f, 60f);
            float weightX150Right = FukaSkinConstraintUtils.AngleToWeightReverse(_x150RightAngleSource, 0f, 60f);

            int bsX150AnusIndex = _mesh.sharedMesh.GetBlendShapeIndex(_x150AnusBlendShapeName);
            if (bsX150AnusIndex >= 0) _mesh.SetBlendShapeWeight(bsX150AnusIndex, (weightX150Left + weightX150Right) / 2f);
        }
    }
}