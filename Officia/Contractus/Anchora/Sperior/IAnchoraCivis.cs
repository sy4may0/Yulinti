using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;
using RootMotion.FinalIK;
using Animancer;

namespace Yulinti.Officia.Contractus {
    public interface IAnchoraCivis : IAnchora, IPhantasma {
        bool PonoSchemam(AssetReferenceGameObject schemam);
        Animator Animator { get; }
        AnimancerComponent Animancer { get; }
        SkinnedMeshRenderer Figura { get; }
        NavMeshAgent NavMeshAgent { get; }
        LookAtIK LookAtIK { get; }
        Transform Capitis { get; }

        IAnchoraVelumSpatiiCivisVeletudinis VelumVeletudinis { get; }
    }
}
