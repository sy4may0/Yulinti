using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeFiguraeGenus {
        NihilAut<SkinnedMeshRenderer> Mesh { get; }
        string X90BlendShapeName { get; }
        string X150BlendShapeName { get; }
        string X120OffsetBlendShapeName { get; }
    }
}
