using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using Animancer;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraCivis : IAnchora, IPhantasma {
        Animator Animator { get; }
        AnimancerComponent Animancer { get; }
        SkinnedMeshRenderer Figura { get; }
        NavMeshAgent NavMeshAgent { get; }
        Transform Capitis { get; }
    }
}
