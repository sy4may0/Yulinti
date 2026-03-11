using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Animancer;
using Cysharp.Threading.Tasks;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Imperium.Anchora {
    public sealed class AnchoraCivis : MonoBehaviour, IAnchora, IPhantasma, IAnchoraCivis {
        [SerializeField] private AssetReferenceGameObject _prefab;

        private GameObject _ens;
        private AnchoraCivisInf _anchoraInf;

        private bool _estEns;

        public Animator Animator => _anchoraInf?.Animator;
        public AnimancerComponent Animancer => _anchoraInf?.Animancer;
        public SkinnedMeshRenderer Figura => _anchoraInf?.SkinnedMeshRenderer;
        public NavMeshAgent NavMeshAgent => _anchoraInf?.NavMeshAgent;
        public Transform Capitis => _anchoraInf?.Capitis;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_prefab == null) {
                Carnifex.Intermissio(LogTextus.AnchoraCivis_ANCHORACIVIS_PREFAB_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public async UniTask Manifestatio() {
            var handle = _prefab.InstantiateAsync(
                Vector3.zero,
                Quaternion.identity
            );

            _ens = await handle.Task;
            _ens.transform.SetParent(transform, false);
            _ens.transform.localPosition = Vector3.zero;
            _ens.transform.localRotation = Quaternion.identity;
            _ens.transform.localScale = Vector3.one;

            await UniTask.SwitchToMainThread();

            _anchoraInf = _ens.GetComponent<AnchoraCivisInf>();
            _ens.SetActive(false);

            if (ValidareManifestatio()) {
                _estEns = true;
            } else {
                Deleto();
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_INSTANTIATE_FAILED);
            }
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
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_INSTANCE_NULL);
                result = false;
            }
            if (_anchoraInf == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_INFERIOR_ANCHOR_NULL);
                result = false;
            }
            if (_anchoraInf.Animator == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_ANIMATOR_NULL);
                result = false;
            }
            if (_anchoraInf.Animancer == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_ANIMANCER_NULL);
                result = false;
            }
            if (_anchoraInf.SkinnedMeshRenderer == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_SKINNEDMESHRENDERER_NULL);
                result = false;
            }
            if (_anchoraInf.NavMeshAgent == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_NAVMESHAGENT_NULL);
                result = false;
            }
            if (_anchoraInf.Capitis == null) {
                Notarius.Memorare(LogTextus.AnchoraCivis_ANCHORACIVIS_CAPITIS_NULL);
                result = false;
            }
            return result;
        }

        public bool EstEns => _estEns;
        public bool EstActivum => _estEns && _ens.activeSelf;
        
    }
}
