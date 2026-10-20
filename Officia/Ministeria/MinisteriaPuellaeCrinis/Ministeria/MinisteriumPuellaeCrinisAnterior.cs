using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeCrinisAnterior {
        private readonly TabulaPuellaeCrinisAnterior _tabulaCrinis;
        private IAnchoraPuellaeCrinisAnterior _crinisActualis;
        private Transform _osCaputis;

        public MinisteriumPuellaeCrinisAnterior(IAnchoraPuellaeCrinisAnterior[] anchora, IAnchoraPuellae anchoraPuellae) {
            _tabulaCrinis = new TabulaPuellaeCrinisAnterior(anchora);
            _crinisActualis = null;
            _osCaputis = anchoraPuellae.OsHead;
        }

        public void Muto(IDPuellaeCrinisAnterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisAnterior.Nihil) {
                Deleto();
                return;
            }
            MutoAsync(idCrinis).Forget(e => Notarius.Memorare(e));
        }

        public async UniTask MutoAsync(IDPuellaeCrinisAnterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisAnterior.Nihil) {
                Deleto();
                return;
            }
            if (_crinisActualis != null && _crinisActualis.Typus == idCrinis) {
                return;
            }

            IAnchoraPuellaeCrinisAnterior neo = _tabulaCrinis.Lego(idCrinis);
            await neo.Manifestatio();
            bool result = neo.ValidareManifestatio();

            if (result) {
                if (_crinisActualis != null) {
                    _crinisActualis.Deleto();
                }
                _crinisActualis = neo;

                Transform radix = neo.OsRadix;
                radix.SetParent(_osCaputis);
                radix.localPosition = Vector3.zero;
                radix.localRotation = Quaternion.identity;
                _crinisActualis.Incarnare();
            } else {
                neo.Deleto();
                Notarius.Memorare(LogTextus.MinisteriumPuellaeCrinisAnterior_MINISTERIUMPUELLAECRINISANTERIOR_INSTANTIATE_FAILED);
            }
        }

        public void Deleto() {
            if (_crinisActualis != null) {
                _crinisActualis.Spirituare();
                _crinisActualis.Deleto();
            }
            _crinisActualis = null;
        }
    }
}
