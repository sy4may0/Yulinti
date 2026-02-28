using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeFiguraeGenusSinister : IConfiguratioPuellaeFiguraeGenusSinister {
        [SerializeField] private string _x90BlendShapeName = "fuka.act.cs.kneefix90.l";
        [SerializeField] private string _x150BlendShapeName = "fuka.act.cs.kneefix160.l";
        [SerializeField] private string _x120OffsetBlendShapeName = "fuka.act.cs.kneefx120sub.l";
 
        public string X90BlendShapeName => _x90BlendShapeName;
        public string X150BlendShapeName => _x150BlendShapeName;
        public string X120OffsetBlendShapeName => _x120OffsetBlendShapeName;
    }
}
