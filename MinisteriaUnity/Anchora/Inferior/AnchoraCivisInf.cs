using UnityEngine;
using Animancer;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraCivisInf : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform _capitis;

        public Animator Animator => _animator;
        public AnimancerComponent Animancer => _animancer;
        public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
        public UnityEngine.AI.NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Transform Capitis => _capitis;
    }
}
