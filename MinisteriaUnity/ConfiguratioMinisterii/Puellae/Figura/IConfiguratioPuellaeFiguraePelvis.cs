using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeFiguraePelvis {
        NihilAut<SkinnedMeshRenderer> Mesh { get; }
        string LeftX90BlendShapeName { get; }
        string LeftX150BlendShapeName { get; }
        string LeftY90BlendShapeName { get; }
        string RightX90BlendShapeName { get; }
        string RightX150BlendShapeName { get; }
        string RightY90BlendShapeName { get; }
        string X150AnusBlendShapeName { get; }
    }
}
