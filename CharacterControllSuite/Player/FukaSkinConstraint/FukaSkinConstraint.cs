using UnityEngine;

// 膝と股関節はシェイプ適用が線形ではない。
// したがって、Animancerのフェードなどでシェイプを線形補完するとおかしくなる。
// Unity側で再計算して適用しなおす。
// 肩と肘のコレクティブシェイプは1つしかなく、線形補完で問題無いため、。ここに処理はかかない。
//
// アセットのアニメーションとか使う場合は、当然ながら、シェイプがFBXに埋め込まれていない。
// その場合は肩と肘のコレクティブシェイプを追加する。

namespace Yulinti.CharacterControllSuite {
    public sealed class FukaSkinConstraint {
        private FukaSkinConstraintConfig _config;

        private FukaKneeCorrectiveShape _rightKneeCorrectiveShape;
        private FukaKneeCorrectiveShape _leftKneeCorrectiveShape;
        private FukaHipsCorrectiveShape _rightHipsCorrectiveShape;
        private FukaHipsCorrectiveShape _leftHipsCorrectiveShape;
        private FukaKetsuCorrectiveShape _ketsuCorrectiveShape;

        private Transform _rightUpperLeg;
        private Transform _rightLowerLeg;
        private Transform _rightFoot;
        private Transform _leftUpperLeg;
        private Transform _leftLowerLeg;
        private Transform _leftFoot;

        private Transform _rightX90pin;
        private Transform _rightX150pin;
        private Transform _rightY90pin;
        private Transform _leftX90pin;
        private Transform _leftX150pin;
        private Transform _leftY90pin;

        public FukaSkinConstraint(
            FukaSkinConstraintConfig config
        ) {
            _config = config;
            SetupCorrectiveShapes(
                config.KneeCorrectiveShapeConfig,
                config.HipsCorrectiveShapeConfig
            );
        }

        private void SetupCorrectiveShapes(
            FukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig,
            FukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig
        ) {
            _rightKneeCorrectiveShape = new FukaKneeCorrectiveShape(
                _config.RightLegMesh,
                kneeCorrectiveShapeConfig.Right90BlendShapeName, 
                kneeCorrectiveShapeConfig.Right150BlendShapeName, 
                kneeCorrectiveShapeConfig.Right120OffsetBlendShapeName
            );
            _leftKneeCorrectiveShape = new FukaKneeCorrectiveShape(
                _config.LeftLegMesh,
                kneeCorrectiveShapeConfig.Left90BlendShapeName,
                kneeCorrectiveShapeConfig.Left150BlendShapeName,
                kneeCorrectiveShapeConfig.Left120OffsetBlendShapeName
            );
            _rightHipsCorrectiveShape = new FukaHipsCorrectiveShape(
                _config.HipsMesh,
                hipsCorrectiveShapeConfig.RightX90BlendShapeName,
                hipsCorrectiveShapeConfig.RightX150BlendShapeName,
                hipsCorrectiveShapeConfig.RightY90BlendShapeName
            );
            _leftHipsCorrectiveShape = new FukaHipsCorrectiveShape(
                _config.HipsMesh,
                hipsCorrectiveShapeConfig.LeftX90BlendShapeName,
                hipsCorrectiveShapeConfig.LeftX150BlendShapeName,
                hipsCorrectiveShapeConfig.LeftY90BlendShapeName
            );
            _ketsuCorrectiveShape = new FukaKetsuCorrectiveShape(
                _config.HipsMesh,
                hipsCorrectiveShapeConfig.X150AnusBlendShapeName
            );

            _rightUpperLeg = _config.RigRoot.Find("root/Hips/RightUpperLeg");
            _rightLowerLeg = _config.RigRoot.Find("root/Hips/RightUpperLeg/RightLowerLeg");
            _rightFoot = _config.RigRoot.Find("root/Hips/RightUpperLeg/RightLowerLeg/RightFoot");
            _leftUpperLeg = _config.RigRoot.Find("root/Hips/LeftUpperLeg");
            _leftLowerLeg = _config.RigRoot.Find("root/Hips/LeftUpperLeg/LeftLowerLeg");
            _leftFoot = _config.RigRoot.Find("root/Hips/LeftUpperLeg/LeftLowerLeg/LeftFoot");

            _rightX150pin = _config.RigRoot.Find("root/Hips/LegJointX150.r");
            _rightY90pin = _config.RigRoot.Find("root/Hips/LegJointY90.r");
            _leftX150pin = _config.RigRoot.Find("root/Hips/LegJointX150.l");
            _leftY90pin = _config.RigRoot.Find("root/Hips/LegJointY90.l");
        }

        public void ApplyAll() {
            ApplyKneeCollectiveShape();
            ApplyHipsCollectiveShape();
        }


        public void ApplyKneeCollectiveShape() {
            if (_config.RigRoot == null) {
                return;
            }
            float rightKneeAngle = FukaSkinConstraintUtils.GetThreePointAngle(_rightLowerLeg, _rightUpperLeg, _rightFoot);
            float leftKneeAngle = FukaSkinConstraintUtils.GetThreePointAngle(_leftLowerLeg, _leftUpperLeg, _leftFoot);

            _rightKneeCorrectiveShape?.SetAngleSource(rightKneeAngle);
            _leftKneeCorrectiveShape?.SetAngleSource(leftKneeAngle);

            _rightKneeCorrectiveShape?.Apply();
            _leftKneeCorrectiveShape?.Apply();
        }

        public void ApplyHipsCollectiveShape() {
            if (_config.RigRoot == null) {
                return;
            }
            float leftX150angle = FukaSkinConstraintUtils.GetThreePointAngle(_leftUpperLeg, _leftX150pin, _leftLowerLeg);
            float leftY90angle = FukaSkinConstraintUtils.GetThreePointAngle(_leftUpperLeg, _leftY90pin, _leftLowerLeg);

            float rightX150angle = FukaSkinConstraintUtils.GetThreePointAngle(_rightUpperLeg, _rightX150pin, _rightLowerLeg);
            float rightY90angle = FukaSkinConstraintUtils.GetThreePointAngle(_rightUpperLeg, _rightY90pin, _rightLowerLeg);

            _leftHipsCorrectiveShape?.SetXAngleSource(leftX150angle);
            _leftHipsCorrectiveShape?.SetYAngleSource(leftY90angle);

            _rightHipsCorrectiveShape?.SetXAngleSource(rightX150angle);
            _rightHipsCorrectiveShape?.SetYAngleSource(rightY90angle);

            _ketsuCorrectiveShape?.SetX150LeftAngleSource(leftX150angle);
            _ketsuCorrectiveShape?.SetX150RightAngleSource(rightX150angle);

            _leftHipsCorrectiveShape?.Apply();
            _rightHipsCorrectiveShape?.Apply();
            _ketsuCorrectiveShape?.Apply();
        }
    }
}