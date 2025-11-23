using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FabricaCivisOrdinatae : IFabricaCivis {
        private readonly GameObject _civisPrefab;
        private readonly GameObject _civisInstance;

        public FabricaCivisOrdinatae(NihilAut<GameObject> civisPrefab) {
            _civisPrefab = civisPrefab.EvolvareNuncium("FabricaCivisOrdinataeのCivisPrefabがnullです。");
        }

        public NihilAut<GameObject> ManifestatioCivis() {
            return new NihilAut<GameObject>(UnityEngine.Object.Instantiate(_civisPrefab));
        }

        public void DeletioCivis(NihilAut<GameObject> civis) {
            if (civis.Nihil()) {
                return;
            }
            UnityEngine.Object.Destroy(civis.Evolvere());
        }
    }
}