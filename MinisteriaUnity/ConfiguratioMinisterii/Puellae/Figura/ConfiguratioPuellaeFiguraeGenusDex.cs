using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFiguraeGenusDex : IConfiguratioPuellaeFiguraeGenus {
        [Header("ConfiguratioPuellaeFiguraeGenusDex/メッシュ")]
        [SerializeField] private SkinnedMeshRenderer _mesh;
        [Header("ConfiguratioPuellaeFiguraeGenusDex/ブレンドシェイプ名")]
        [SerializeField] private string _x90BlendShapeName = "fuka.act.cs.kneefix90.r";
        [SerializeField] private string _x150BlendShapeName = "fuka.act.cs.kneefix160.r";
        [SerializeField] private string _x120OffsetBlendShapeName = "fuka.act.cs.kneefx120sub.r";

        public NihilAut<SkinnedMeshRenderer> Mesh => new NihilAut<SkinnedMeshRenderer>(_mesh);
        public string X90BlendShapeName => _x90BlendShapeName;
        public string X150BlendShapeName => _x150BlendShapeName;
        public string X120OffsetBlendShapeName => _x120OffsetBlendShapeName;
    }
}
