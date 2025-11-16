using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeFiguraeGenus {
        SkinnedMeshRenderer Mesh { get; }
        string X90BlendShapeName { get; }
        string X150BlendShapeName { get; }
        string X120OffsetBlendShapeName { get; }
    }
}