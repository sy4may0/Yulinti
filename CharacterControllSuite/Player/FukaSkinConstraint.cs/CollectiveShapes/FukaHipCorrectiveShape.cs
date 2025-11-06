using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    public sealed class FukaHipsCorrectiveShape : IFukaCorrectiveShape
    {
        private SkinnedMeshRenderer _mesh;
        private float _xAngleSource;
        private float _yAngleSource;
        private string _x90BlendShapeName;
        private string _x150BlendShapeName;
        private string _y90BlendShapeName;

        public FukaHipsCorrectiveShape(
            SkinnedMeshRenderer mesh,
            string blendShapeX90Name,
            string blendShapeX150Name,
            string blendShapeY90Name
        )
        {
            _mesh = mesh;
            _x90BlendShapeName = blendShapeX90Name;
            _x150BlendShapeName = blendShapeX150Name;
            _y90BlendShapeName = blendShapeY90Name;
        }


        public void SetXAngleSource(float angle)
        {
            _xAngleSource = angle;
        }
        public void SetYAngleSource(float angle)
        {
            _yAngleSource = angle;
        }

        public void Apply()
        {
            float weightX90 = FukaSkinConstraintUtils.AngleToTriWeight(_xAngleSource, 0f, 60f, 150f);
            float weightX150 = FukaSkinConstraintUtils.AngleToWeightReverse(_xAngleSource, 0f, 60f);
            float weightY90 = FukaSkinConstraintUtils.AngleToWeightReverse(_yAngleSource, 0f, 90f);

            // (X90 + X150) + Y90が100になるように調整する。
            float xcapacity = Mathf.Max(0f, 100f - weightY90);
            float xsum = weightX90 + weightX150;

            if (xsum > xcapacity)
            {
                float scale = xcapacity / Mathf.Max(xsum, 1e-6f);
                weightX90 *= scale;
                weightX150 *= scale;
            }

            int bsLegJointX90Index = _mesh.sharedMesh.GetBlendShapeIndex(_x90BlendShapeName);
            int bsLegJointX150Index = _mesh.sharedMesh.GetBlendShapeIndex(_x150BlendShapeName);
            int bsLegJointY90Index = _mesh.sharedMesh.GetBlendShapeIndex(_y90BlendShapeName);

            if (bsLegJointX90Index >= 0) _mesh.SetBlendShapeWeight(bsLegJointX90Index, weightX90);
            if (bsLegJointX150Index >= 0) _mesh.SetBlendShapeWeight(bsLegJointX150Index, weightX150);
            if (bsLegJointY90Index >= 0) _mesh.SetBlendShapeWeight(bsLegJointY90Index, weightY90);
        }
    }
}