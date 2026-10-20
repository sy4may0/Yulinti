using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraPuellaeCrinisAnterior : MonoBehaviour, IAnchora, IPhantasma, IAnchoraPuellaeCrinisAnterior {
        [SerializeField] private AssetReferenceGameObject _prefab;
        [SerializeField] private IDPuellaeCrinisAnterior _idCrinis;

        private GameObject _ens;
        private AnchoraPuellaeCrinisAnteriorInf _anchoraInf;
        private bool _estEns;
        private bool _estManifestatum;

        public IDPuellaeCrinisAnterior Typus => _idCrinis;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public Transform OsRadix => _anchoraInf.OsRadix;

        public bool Validare() {
            bool result = true;

            if (_prefab == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellaeCrinisAnterior_ANCHORAPUELLAE_CRINIS_ANTERIOR_PREFAB_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public bool ValidareManifestatio() {
            bool result = true;
            if (_ens == null) {
                Notarius.Memorare(LogTextus.AnchoraPuellaeCrinisAnterior_ANCHORAPUELLAE_CRINIS_ANTERIOR_INSTANCE_NULL);
                result = false;
            }
            if (_anchoraInf == null) {
                Notarius.Memorare(LogTextus.AnchoraPuellaeCrinisAnterior_ANCHORAPUELLAE_CRINIS_ANTERIOR_INFERIOR_ANCHOR_NULL);
                result = false;
            } else {
                if (_anchoraInf.OsRadix == null) {
                    Notarius.Memorare(LogTextus.AnchoraPuellaeCrinisAnterior_ANCHORAPUELLAE_CRINIS_ANTERIOR_RADIX_NULL);
                    result = false;
                }
            }
            _estEns = true;
            return result;
        }

        public async UniTask Manifestatio() {
            if (_estManifestatum) return;
            _estManifestatum = true;

            try {
                var handle = _prefab.InstantiateAsync(
                    transform.position,
                    transform.rotation
                );

                _ens = await handle.Task;

                await UniTask.SwitchToMainThread();

                _anchoraInf = _ens.GetComponent<AnchoraPuellaeCrinisAnteriorInf>();
                _ens.SetActive(false);

                if (ValidareManifestatio()) {
                    _estEns = true;
                } else {
                    Deleto();
                    Notarius.Memorare(LogTextus.AnchoraPuellaeCrinisAnterior_ANCHORAPUELLAE_CRINIS_ANTERIOR_INSTANTIATE_FAILED);
                }
            } finally {
                _estManifestatum = false;
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
            Activare();
        }

        public void Spirituare() {
            Deactivare();
        }

        public void Activare() {
            if (!_estEns) return;
            if (_ens.activeSelf) return;
            _ens.SetActive(true);
        }

        public void Deactivare() {
            if (!_estEns) return;
            if (!_ens.activeSelf) return;
            _ens.SetActive(false);
        }

        public bool EstEns => _estEns;
        public bool EstActivum => _estEns && _ens.activeSelf;
        public bool EstManifestatum => _estManifestatum;
        public bool EstSpiritus => _estEns && !_ens.activeSelf;
    }
}
