using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Animancer;
using Cysharp.Threading.Tasks;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraCivis : MonoBehaviour, IAnchora, IPhantasma, IAnchoraCivis {
        [SerializeField] private AssetReferenceGameObject _prefab;

        private GameObject _ens;
        private AnchoraCivisInf _anchoraInf;

        private bool _estEns;

        public Animator Animator => _anchoraInf.Animator;
        public AnimancerComponent Animancer => _anchoraInf.Animancer;
        public SkinnedMeshRenderer Figura => _anchoraInf.SkinnedMeshRenderer;
        public CharacterController CharacterController => _anchoraInf.CharacterController;
        public NavMeshAgent NavMeshAgent => _anchoraInf.NavMeshAgent;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_prefab == null) {
                Errorum.Fatal(IDErrorum.ANCHORACIVIS_PREFAB_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public async UniTask Manifestatio() {
            var handle = _prefab.InstantiateAsync(
                transform.position,
                transform.rotation
            );

            _ens = await handle.Task;
            await UniTask.SwitchToMainThread();

            _anchoraInf = _ens.GetComponent<AnchoraCivisInf>();

            _estEns = true;
        }

        public void Deleto() {
            if (_ens != null) {
                _prefab.ReleaseInstance(_ens);
                _ens = null;
            }
            _estEns = false;
        }

        public void Incarnare() {
            if (!_estEns) return;
            if (_ens.activeSelf) return;
            _ens.SetActive(true);
        }
        
        public void Spirituare() {
            if (!_estEns) return;
            if (!_ens.activeSelf) return;
            _ens.SetActive(false);
        }

        public bool ValidareManifestatio() {
            bool result = true;
            if (_ens == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_INSTANCE_NULL);
                result = false;
            }
            if (_anchoraInf == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_INFERIOR_ANCHOR_NULL);
                result = false;
            }
            if (_anchoraInf.Animator == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_ANIMATOR_NULL);
                result = false;
            }
            if (_anchoraInf.Animancer == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_ANIMANCER_NULL);
                result = false;
            }
            if (_anchoraInf.SkinnedMeshRenderer == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_SKINNEDMESHRENDERER_NULL);
                result = false;
            }
            if (_anchoraInf.CharacterController == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_CHARACTERCONTROLLER_NULL);
                result = false;
            }
            if (_anchoraInf.NavMeshAgent == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORACIVIS_NAVMESHAGENT_NULL);
                result = false;
            }
            return result;
        }

        public bool EstEns => _estEns;
        public bool EstActivum => _estEns && _ens.activeSelf;
        
    }
}
