using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeCrinisAdiunctionis {
        private readonly TabulaPuellaeCrinis _tabulaCrinis;
        private AnchoraPuellaeCrinis _crinisActualis;
        private Transform _osCaputis;

        public MinisteriumPuellaeCrinisAdiunctionis(AnchoraPuellaeCrinis[] anchora, AnchoraPuellae anchoraPuellae) {
            _tabulaCrinis = new TabulaPuellaeCrinis(anchora);
            _crinisActualis = null;
            _osCaputis = anchoraPuellae.OsHead;
        }

        public void Muto(IDPuellaeCrinis idCrinis) {
            MutoAsync(idCrinis).Forget(e => Memorator.MemorareException(e));
        }

        public async UniTask MutoAsync(IDPuellaeCrinis idCrinis) {
            if (_crinisActualis != null && _crinisActualis.Typus == idCrinis) {
                return;
            }
 
            AnchoraPuellaeCrinis neo = _tabulaCrinis.Lego(idCrinis);
            await neo.Manifestatio();
            bool result = neo.ValidareManifestatio();

            if (result) {
                if (_crinisActualis != null) {
                    _crinisActualis.Deleto();
                }
                _crinisActualis = neo;
            } else {
                neo.Deleto();
                Memorator.MemorareErrorum(IDErrorum.MINISTERIUMPUELLAECRINISADIUNCTIONIS_INSTANTIATE_FAILED);
            }

            Transform radix = neo.OsRadix;
            radix.SetParent(_osCaputis);
            radix.localPosition = Vector3.zero;
            radix.localRotation = Quaternion.identity;
        }

        public void Deleto() {
            if (_crinisActualis != null) {
                _crinisActualis.Deleto();
            }
            _crinisActualis = null;
        }
    }
}
