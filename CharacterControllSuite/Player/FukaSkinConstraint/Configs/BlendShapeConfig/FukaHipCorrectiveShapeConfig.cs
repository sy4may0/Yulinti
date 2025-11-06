using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    [System.Serializable]
    public sealed class FukaHipsCorrectiveShapeConfig
    {
        [Tooltip("左腰X90ブレンドシェイプ名")]
        [SerializeField] private string _leftX90BlendShapeName = "fuka.act.cs.legjointX90.l";
        [Tooltip("左腰X150ブレンドシェイプ名")]
        [SerializeField] private string _leftX150BlendShapeName = "fuka.act.cs.legjointX150.l";
        [Tooltip("左腰Y90ブレンドシェイプ名")]
        [SerializeField] private string _leftY90BlendShapeName = "fuka.act.cs.legjointY90.l";
        [Tooltip("右腰X90ブレンドシェイプ名")]
        [SerializeField] private string _rightX90BlendShapeName = "fuka.act.cs.legjointX90.r";
        [Tooltip("右腰X150ブレンドシェイプ名")]
        [SerializeField] private string _rightX150BlendShapeName = "fuka.act.cs.legjointX150.r";
        [Tooltip("右腰Y90ブレンドシェイプ名")]
        [SerializeField] private string _rightY90BlendShapeName = "fuka.act.cs.legjointY90.r";
        [Tooltip("アナル補正ブレンドシェイプ名")]
        [SerializeField] private string _x150AnusBlendShapeName = "fuka.act.cs.legjointfixAnal";

        public string LeftX90BlendShapeName => _leftX90BlendShapeName;
        public string LeftX150BlendShapeName => _leftX150BlendShapeName;
        public string LeftY90BlendShapeName => _leftY90BlendShapeName;
        public string RightX90BlendShapeName => _rightX90BlendShapeName;
        public string RightX150BlendShapeName => _rightX150BlendShapeName;
        public string RightY90BlendShapeName => _rightY90BlendShapeName;
        public string X150AnusBlendShapeName => _x150AnusBlendShapeName;
    }
}

