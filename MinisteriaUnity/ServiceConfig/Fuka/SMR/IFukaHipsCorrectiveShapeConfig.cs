using UnityEngine;
namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaHipsCorrectiveShapeConfig {
        SkinnedMeshRenderer Mesh { get; }
        string LeftX90BlendShapeName { get; }
        string LeftX150BlendShapeName { get; }
        string LeftY90BlendShapeName { get; }
        string RightX90BlendShapeName { get; }
        string RightX150BlendShapeName { get; }
        string RightY90BlendShapeName { get; }
        string X150AnusBlendShapeName { get; }
    }
}