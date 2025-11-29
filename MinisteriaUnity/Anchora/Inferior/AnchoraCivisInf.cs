using UnityEngine;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraCivisInf : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent;

        public Animator Animator => _animator;
        public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
        public CharacterController CharacterController => _characterController;
        public UnityEngine.AI.NavMeshAgent NavMeshAgent => _navMeshAgent;
    }
}