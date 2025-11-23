using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFiguraePelvis : IConfiguratioPuellaeFiguraePelvis {
        [Header("ConfiguratioPuellaeFiguraePelvis/メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _mesh;
        [Header("ConfiguratioPuellaeFiguraePelvis/ブレンドシェイプ名")]
        [SerializeField] private string _leftX90BlendShapeName = "fuka.act.cs.legjointX90.l";
        [SerializeField] private string _leftX150BlendShapeName = "fuka.act.cs.legjointX150.l";
        [SerializeField] private string _leftY90BlendShapeName = "fuka.act.cs.legjointY90.l";
        [SerializeField] private string _rightX90BlendShapeName = "fuka.act.cs.legjointX90.r";
        [SerializeField] private string _rightX150BlendShapeName = "fuka.act.cs.legjointX150.r";
        [SerializeField] private string _rightY90BlendShapeName = "fuka.act.cs.legjointY90.r";
        [SerializeField] private string _x150AnusBlendShapeName = "fuka.act.cs.legjointfixAnal";

        public NihilAut<SkinnedMeshRenderer> Mesh => new NihilAut<SkinnedMeshRenderer>(_mesh);
        public string LeftX90BlendShapeName => _leftX90BlendShapeName;
        public string LeftX150BlendShapeName => _leftX150BlendShapeName;
        public string LeftY90BlendShapeName => _leftY90BlendShapeName;
        public string RightX90BlendShapeName => _rightX90BlendShapeName;
        public string RightX150BlendShapeName => _rightX150BlendShapeName;
        public string RightY90BlendShapeName => _rightY90BlendShapeName;
        public string X150AnusBlendShapeName => _x150AnusBlendShapeName;
    }
}
