using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraCivis : IAnchora, IPhantasma {
        Animator Animator { get; }
        SkinnedMeshRenderer Figura { get; }
        CharacterController CharacterController { get; }
        NavMeshAgent NavMeshAgent { get; }
    }
}
