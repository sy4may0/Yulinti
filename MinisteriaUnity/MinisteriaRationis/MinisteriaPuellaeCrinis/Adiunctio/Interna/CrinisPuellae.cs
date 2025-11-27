using UnityEngine;
using UnityEngine.AddressableAssets;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class CrinisPuellae {
        private GameObject _crinisPrefab;
        private GameObject _crinisInstance;
        private Transform _radix;
        private string _iterAdRadicem;
        private string _nomenAddressables;

        private bool _estManifestionem = false;
        private bool _estDeletionem = false;

        public CrinisPuellae(GameObject crinisPrefab, string iterAdRadicem) {
            if (crinisPrefab == null) {
                Errorum.Fatal(IDErrorum.CRINISPUELLAE_CRINIS_NULL);
            }
            _crinisPrefab = crinisPrefab;
            _iterAdRadicem = iterAdRadicem;
            _nomenAddressables = crinisPrefab.name;
            _radix = null;
            _crinisInstance = null;
            _estManifestionem = false;
            _estDeletionem = false;
        }

        public void Manifestatio(Transform parent) {
            if (_estManifestionem) {
                return;
            }
            Addressables.LoadAssetAsync<GameObject>(_nomenAddressables).Completed += (handle) => {
                GameObject pf = handle.Result;
                _crinisInstance = UnityEngine.Object.Instantiate(pf);

                if (_crinisInstance == null) {
                    Errorum.Fatal(IDErrorum.CRINISPUELLAE_INSTANCE_NOT_FOUND);
                }
                _radix = _crinisInstance.transform.Find(_iterAdRadicem);
                if (_radix == null) {
                    Errorum.Fatal(IDErrorum.CRINISPUELLAE_RADIX_NOT_FOUND);
                }

                _radix.SetParent(parent);
                _radix.localPosition = Vector3.zero;
                _radix.localRotation = Quaternion.identity;

                _estManifestionem = true;
                _estDeletionem = false;
            };
        }

        public void Deletio() {
            if (_crinisInstance == null) {
                return;
            }
            UnityEngine.Object.Destroy(_crinisInstance);
            _crinisInstance = null;
            _radix = null;
            _estManifestionem = false;
            _estDeletionem = true;
        }

        public bool EstManifestionem => _estManifestionem;
        public bool EstDeletionem => _estDeletionem;
    }
}
