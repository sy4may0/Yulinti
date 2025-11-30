using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.Anchora {
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
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_CRINIS_PREFAB_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public bool ValidareManifestatio() {
            bool result = true;
            if (_ens == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORAPUELLAE_CRINIS_INSTANCE_NULL);
                result = false;
            }
            if (_anchoraInf == null) {
                Memorator.MemorareErrorum(IDErrorum.ANCHORAPUELLAE_CRINIS_INFERIOR_ANCHOR_NULL);
                result = false;
            } else {
                if (_anchoraInf.OsRadix == null) {
                    Memorator.MemorareErrorum(IDErrorum.ANCHORAPUELLAE_CRINIS_RADIX_NULL);
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
        }

        public void Deleto() {
            if (_ens != null) {
                _prefab.ReleaseInstance(_ens);
                _ens = null;
            }
            _estEns = false;
        }

        public bool EstEns => _estEns;
    }
}
