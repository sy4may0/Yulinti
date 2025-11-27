using UnityEngine.AI;
using UnityEngine;
using System;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class CivisAtomi : ICivisAtomi, IDisposable {
        // 基本コンポーネント
        private readonly GameObject _radixCivis;
        private readonly GameObject _civis;
        private readonly CharacterController _characterController;
        private readonly Animator _animator;
        private readonly SkinnedMeshRenderer _figura;
        private NavMeshAgent _navMeshAgent;

        public CivisAtomi(GameObject prefabCivis) {
            _radixCivis = UnityEngine.Object.Instantiate(prefabCivis);
            if (_radixCivis == null) {
                Errorum.Fatal(IDErrorum.CIVISATOMI_INSTANTIATE_FAILED);
            }
            // 基本コンポーネント
            AnchoraCivis anchora = _radixCivis.GetComponent<AnchoraCivis>();
            if (anchora == null) {
                Errorum.Fatal(IDErrorum.CIVISATOMI_NO_ANCHOR_IN_ROOT);
            }
            _civis = anchora.Civis();
            _characterController = anchora.CharacterController();
            _animator = anchora.Animator();
            _figura = anchora.Figura();
            _navMeshAgent = anchora.NavMeshAgent();
        }

        public GameObject RadixCivis => _radixCivis;
        public NihilAut<GameObject> Civis => new NihilAut<GameObject>(_civis);
        public NihilAut<CharacterController> CharacterController => new NihilAut<CharacterController>(_characterController);
        public NihilAut<Animator> Animator => new NihilAut<Animator>(_animator);
        public NihilAut<SkinnedMeshRenderer> Figura => new NihilAut<SkinnedMeshRenderer>(_figura);
        public NihilAut<NavMeshAgent> NavMeshAgent => new NihilAut<NavMeshAgent>(_navMeshAgent);

        public void Activare() {
            _radixCivis.SetActive(true);
        }

        public void Deactivare() {
            _radixCivis.SetActive(false);
        }

        public bool EstActivum() {
            return _radixCivis.activeSelf;
        }

        public void Dispose() {
            UnityEngine.Object.Destroy(_radixCivis);
        }
    }
}