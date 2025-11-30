using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFiguraeGenusDex : IConfiguratioPuellaeFiguraeGenus {
        [SerializeField] private string _x90BlendShapeName = "fuka.act.cs.kneefix90.r";
        [SerializeField] private string _x150BlendShapeName = "fuka.act.cs.kneefix160.r";
        [SerializeField] private string _x120OffsetBlendShapeName = "fuka.act.cs.kneefx120sub.r";

        public string X90BlendShapeName => _x90BlendShapeName;
        public string X150BlendShapeName => _x150BlendShapeName;
        public string X120OffsetBlendShapeName => _x120OffsetBlendShapeName;
    }
}
