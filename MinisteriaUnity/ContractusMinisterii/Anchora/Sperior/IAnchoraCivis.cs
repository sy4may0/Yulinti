using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using Animancer;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraCivis : IAnchora, IPhantasma {
        Animator Animator { get; }
        AnimancerComponent Animancer { get; }
        SkinnedMeshRenderer Figura { get; }
        CharacterController CharacterController { get; }
        NavMeshAgent NavMeshAgent { get; }
    }
}
