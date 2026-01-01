using UnityEngine;
using Animancer;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPuellae : IAnchora {
        CharacterController CharacterController { get; }
        UnityEngine.AI.NavMeshAgent NavMeshAgent { get; }
        Animator Animator { get; }
        AnimancerComponent Animancer { get; }

        SkinnedMeshRenderer FiguraCapitis { get; }
        SkinnedMeshRenderer FiguraPelvis { get; }
        SkinnedMeshRenderer FiguraCorporis { get; }
        SkinnedMeshRenderer FiguraBrachiiDexter { get; }
        SkinnedMeshRenderer FiguraBrachiiSinister { get; }
        SkinnedMeshRenderer FiguraPedisDexter { get; }
        SkinnedMeshRenderer FiguraPedisSinister { get; }

        Transform OsRadix { get; }
        Transform OsHips { get; }
        Transform OsSpine { get; }
        Transform OsSpine1 { get; }
        Transform OsSpine2 { get; }
        Transform OsNeck { get; }
        Transform OsHead { get; }
        Transform OsLeftShoulder { get; }
        Transform OsLeftUpperArm { get; }
        Transform OsLeftLowerArm { get; }
        Transform OsLeftHand { get; }
        Transform OsRightShoulder { get; }
        Transform OsRightUpperArm { get; }
        Transform OsRightLowerArm { get; }
        Transform OsRightHand { get; }
        Transform OsLeftUpperLeg { get; }
        Transform OsLeftLowerLeg { get; }
        Transform OsLeftFoot { get; }
        Transform OsLeftToe { get; }
        Transform OsRightUpperLeg { get; }
        Transform OsRightLowerLeg { get; }
        Transform OsRightFoot { get; }
        Transform OsRightToe { get; }

        Transform OsHipsRightX150Pin { get; }
        Transform OsHipsRightY90Pin { get; }
        Transform OsHipsLeftX150Pin { get; }
        Transform OsHipsLeftY90Pin { get; }
    }
}
