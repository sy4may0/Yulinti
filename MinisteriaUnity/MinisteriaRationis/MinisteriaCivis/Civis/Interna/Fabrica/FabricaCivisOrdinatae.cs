using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

// Fabricaはコンストラクタ以外で使うな。Spqwn処理中に生成するな。
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FabricaCivisOrdinatae : IFabricaCivis {
        private readonly GameObject _civisPrefab;
        private readonly IConfiguratioCivisOrdinatae _configuratio;

        public FabricaCivisOrdinatae(IConfiguratioCivisOrdinatae configuratio) {
            _configuratio = configuratio;
            _civisPrefab = _configuratio.CivisPrefab.Evolvo(IDErrorum.MINISTERIUMCIVIS_CIVIS_PREFAB_NULL);
        }

        public ErrorAut<ICivisAtomi> ManifestatioCivis() {
            ICivisAtomi civisAtomi = new CivisAtomi(_civisPrefab);
            return ErrorAut<ICivisAtomi>.Successus(civisAtomi);
        }

        public void DeletioCivis(ICivisAtomi civis) {
            if (civis == null) {
                return;
            }
            UnityEngine.Object.Destroy(civis.RadixCivis);
        }
    }
}
