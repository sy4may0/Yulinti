using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeCrinisPosterior {
        private readonly TabulaPuellaeCrinisPosterior _tabulaCrinis;
        private IAnchoraPuellaeCrinisPosterior _crinisActualis;
        private Transform _osCaputis;

        public MinisteriumPuellaeCrinisPosterior(IAnchoraPuellaeCrinisPosterior[] anchora, IAnchoraPuellae anchoraPuellae) {
            _tabulaCrinis = new TabulaPuellaeCrinisPosterior(anchora);
            _crinisActualis = null;
            _osCaputis = anchoraPuellae.OsHead;
        }

        public void Muto(IDPuellaeCrinisPosterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisPosterior.Nihil) {
                Deleto();
                return;
            }
            MutoAsync(idCrinis).Forget(e => Notarius.Memorare(e));
        }

        public async UniTask MutoAsync(IDPuellaeCrinisPosterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisPosterior.Nihil) {
                Deleto();
                return;
            }
            if (_crinisActualis != null && _crinisActualis.Typus == idCrinis) {
                return;
            }

            IAnchoraPuellaeCrinisPosterior neo = _tabulaCrinis.Lego(idCrinis);
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
                Notarius.Memorare(LogTextus.MinisteriumPuellaeCrinisPosterior_MINISTERIUMPUELLAECRINISPOSTERIOR_INSTANTIATE_FAILED);
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
