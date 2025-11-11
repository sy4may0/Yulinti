using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaGrounderConfig {
        Transform LeftFoot { get; }
        Transform LeftToe { get; }
        Transform RightFoot { get; }
        Transform RightToe { get; }
        Transform Root { get; }
        float CastHeight { get; }
        float CastDistance { get; }
        LayerMask CastLayer { get; }
        float Epsilon { get; }
        float ToeYCorrection { get; }
        float FootYCorrection { get; }
    }
}