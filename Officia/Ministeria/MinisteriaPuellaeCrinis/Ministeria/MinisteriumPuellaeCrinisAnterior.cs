using System.Threading;
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
        private readonly ISignumCancellationisLegibile _signumCancellationis;
        private IAnchoraPuellaeCrinisAnterior _crinisActualis;
        private Transform _osCaputis;

        // 生成中に受けた要求は捨てず、最後の要求だけを生成完了後に反映する。
        private bool _estMutans;
        private IDPuellaeCrinisAnterior _idPetitum;

        public MinisteriumPuellaeCrinisAnterior(
            IAnchoraPuellaeCrinisAnterior[] anchora,
            IAnchoraPuellae anchoraPuellae,
            ISignumCancellationisLegibile signumCancellationis
        ) {
            _tabulaCrinis = new TabulaPuellaeCrinisAnterior(anchora);
            _signumCancellationis = signumCancellationis;
            _crinisActualis = null;
            _osCaputis = anchoraPuellae.OsHead;
            _estMutans = false;
            _idPetitum = IDPuellaeCrinisAnterior.Nihil;
        }

        public void Muto(IDPuellaeCrinisAnterior idCrinis) {
            MutoAsync(idCrinis).Forget(e => Notarius.Memorare(e));
        }

        public void Deleto() {
            Muto(IDPuellaeCrinisAnterior.Nihil);
        }

        private async UniTask MutoAsync(IDPuellaeCrinisAnterior idCrinis) {
            _idPetitum = idCrinis;
            if (_estMutans) return;
            _estMutans = true;

            try {
                CancellationToken ct = _signumCancellationis.Signum;
                IDPuellaeCrinisAnterior idTractatum;
                do {
                    idTractatum = _idPetitum;
                    await MutoUnum(idTractatum, ct);
                } while (!ct.IsCancellationRequested && _idPetitum != idTractatum);
            } finally {
                _estMutans = false;
            }
        }

        private async UniTask MutoUnum(IDPuellaeCrinisAnterior idCrinis, CancellationToken ct) {
            if (idCrinis == IDPuellaeCrinisAnterior.Nihil) {
                DeletoActualis();
                return;
            }
            if (_crinisActualis != null && _crinisActualis.Typus == idCrinis) {
                return;
            }

            IAnchoraPuellaeCrinisAnterior neo = _tabulaCrinis.Lego(idCrinis);
            await neo.Manifestatio();

            // InstantiateAsyncは中断できないため、完了後にキャンセルを確認して破棄する。
            if (ct.IsCancellationRequested) {
                neo.Deleto();
                return;
            }

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

        private void DeletoActualis() {
            if (_crinisActualis != null) {
                _crinisActualis.Spirituare();
                _crinisActualis.Deleto();
            }
            _crinisActualis = null;
        }
    }
}
