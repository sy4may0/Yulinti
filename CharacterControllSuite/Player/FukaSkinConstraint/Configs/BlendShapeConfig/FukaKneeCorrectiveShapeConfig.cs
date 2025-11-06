using UnityEngine;

namespace Yulinti.CharacterControllSuite
{
    [System.Serializable]
    public sealed class FukaKneeCorrectiveShapeConfig {
        [Tooltip("左ひざ90度ブレンドシェイプ名")]
        [SerializeField] private string _left90BlendShapeName = "fuka.act.cs.kneefix90.l";
        [Tooltip("左ひざ150度ブレンドシェイプ名")]
        [SerializeField] private string _left150BlendShapeName = "fuka.act.cs.kneefix160.l";
        [Tooltip("左ひざ120度オフセットブレンドシェイプ名")]
        [SerializeField] private string _left120OffsetBlendShapeName = "fuka.act.cs.kneefix120sub.l";
        [Tooltip("右ひざ90度ブレンドシェイプ名")]
        [SerializeField] private string _right90BlendShapeName = "fuka.act.cs.kneefix90.r";
        [Tooltip("右ひざ150度ブレンドシェイプ名")]
        [SerializeField] private string _right150BlendShapeName = "fuka.act.cs.kneefix160.r";
        [Tooltip("右ひざ120度オフセットブレンドシェイプ名")]
        [SerializeField] private string _right120OffsetBlendShapeName = "fuka.act.cs.kneefix120sub.r";

        public string Left90BlendShapeName => _left90BlendShapeName;
        public string Left150BlendShapeName => _left150BlendShapeName;
        public string Left120OffsetBlendShapeName => _left120OffsetBlendShapeName;
        public string Right90BlendShapeName => _right90BlendShapeName;
        public string Right150BlendShapeName => _right150BlendShapeName;
        public string Right120OffsetBlendShapeName => _right120OffsetBlendShapeName;

    }

}