using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaKneeCorrectiveShapeConfig {
        SkinnedMeshRenderer Mesh { get; }
        string X90BlendShapeName { get; }
        string X150BlendShapeName { get; }
        string X120OffsetBlendShapeName { get; }
    }
}