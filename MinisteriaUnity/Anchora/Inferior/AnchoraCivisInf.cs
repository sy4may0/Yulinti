using UnityEngine;
using Animancer;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraCivisInf : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent;

        public Animator Animator => _animator;
        public AnimancerComponent Animancer => _animancer;
        public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
        public CharacterController CharacterController => _characterController;
        public UnityEngine.AI.NavMeshAgent NavMeshAgent => _navMeshAgent;
    }
}
