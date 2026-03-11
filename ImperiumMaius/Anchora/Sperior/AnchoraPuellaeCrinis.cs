using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus;

using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraPuellaeCrinis : MonoBehaviour, IAnchora, IPhantasma, IAnchoraPuellaeCrinis {
        [SerializeField] private AssetReferenceGameObject _prefab;
        [SerializeField] private IDPuellaeCrinis _idCrinis;

        private GameObject _ens;
        private AnchoraPuellaeCrinisInf _anchoraInf;
        private bool _estEns;

        public IDPuellaeCrinis Typus => _idCrinis;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public Transform OsRadix => _anchoraInf.OsRadix;

        public bool Validare() {
            bool result = true;

            if (_prefab == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellaeCrinis_ANCHORAPUELLAE_CRINIS_PREFAB_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public bool ValidareManifestatio() {
            bool result = true;
            if (_ens == null) {
                Notarius.Memorare(LogTextus.AnchoraPuellaeCrinis_ANCHORAPUELLAE_CRINIS_INSTANCE_NULL);
                result = false;
            }
            if (_anchoraInf == null) {
                Notarius.Memorare(LogTextus.AnchoraPuellaeCrinis_ANCHORAPUELLAE_CRINIS_INFERIOR_ANCHOR_NULL);
                result = false;
            } else {
                if (_anchoraInf.OsRadix == null) {
                    Notarius.Memorare(LogTextus.AnchoraPuellaeCrinis_ANCHORAPUELLAE_CRINIS_RADIX_NULL);
                    result = false;
                }
            }
            _estEns = true;
            return result;
        }

        public async UniTask Manifestatio() {
            var handle = _prefab.InstantiateAsync(
                transform.position,
                transform.rotation
            );

            _ens = await handle.Task;

            await UniTask.SwitchToMainThread();

            _anchoraInf = _ens.GetComponent<AnchoraPuellaeCrinisInf>();
            _ens.SetActive(false);

            if (ValidareManifestatio()) {
                _estEns = true;
            } else {
                Deleto();
                Notarius.Memorare(LogTextus.AnchoraPuellaeCrinis_ANCHORAPUELLAE_CRINIS_INSTANTIATE_FAILED);
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

        public bool EstEns => _estEns;
        public bool EstActivum => _estEns && _ens.activeSelf;
    }
}
