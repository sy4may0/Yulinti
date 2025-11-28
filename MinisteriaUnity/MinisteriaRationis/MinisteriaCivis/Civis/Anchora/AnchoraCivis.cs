using UnityEngine;
using UnityEngine.AI;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class AnchoraCivis : MonoBehaviour {
        [SerializeField] private GameObject _prefabInstance;
        [SerializeField] private Animator _animator;
        [SerializeField] private SkinnedMeshRenderer _figura;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public GameObject Civis() => _prefabInstance;
        public Animator Animator() => _animator;
        public SkinnedMeshRenderer Figura() => _figura;
        public CharacterController CharacterController() => _characterController;
        public NavMeshAgent NavMeshAgent() => _navMeshAgent;
    }
}
