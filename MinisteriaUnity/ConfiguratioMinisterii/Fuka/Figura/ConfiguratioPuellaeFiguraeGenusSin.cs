using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFiguraeGenusSin : IConfiguratioPuellaeFiguraeGenus {
        [Header("ConfiguratioPuellaeFiguraeGenusSin/メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _mesh;
        [Header("ConfiguratioPuellaeFiguraeGenusSin/ブレンドシェイプ名")]
        [SerializeField] private string _x90BlendShapeName = "fuka.act.cs.kneefix90.l";
        [SerializeField] private string _x150BlendShapeName = "fuka.act.cs.kneefix160.l";
        [SerializeField] private string _x120OffsetBlendShapeName = "fuka.act.cs.kneefx120sub.l";

        public SkinnedMeshRenderer Mesh => _mesh;
        public string X90BlendShapeName => _x90BlendShapeName;
        public string X150BlendShapeName => _x150BlendShapeName;
        public string X120OffsetBlendShapeName => _x120OffsetBlendShapeName;
    }
}