using UnityEngine;
using Animancer;
using RootMotion.FinalIK;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraCivisInf : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent;
        [SerializeField] private LookAtIK _lookAtIK;
        [SerializeField] private Transform _capitis;
        [SerializeField] private AnchoraVelumSpatiiCivisVeletudinis _anchoraVelumSpatiiCivisVeletudinis;

        public Animator Animator => _animator;
        public AnimancerComponent Animancer => _animancer;
        public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
        public UnityEngine.AI.NavMeshAgent NavMeshAgent => _navMeshAgent;
        public LookAtIK LookAtIK => _lookAtIK;
        public Transform Capitis => _capitis;
        public AnchoraVelumSpatiiCivisVeletudinis AnchoraVelumSpatiiCivisVeletudinis => _anchoraVelumSpatiiCivisVeletudinis;
    }
}
