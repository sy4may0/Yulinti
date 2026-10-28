using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeFormae : IExecutorPuellae {
        private readonly ITurrisPhantasmaPuellaeFormarum _turrisPhantasmaPuellaeFormarum;
        private readonly IPhantasmaPuellaeFormarumLegibile _phantasmaPuellaeFormarumLegibile;
        private IOstiumPuellaeFormaeMutabile _ostiumPuellaeFormaeMutabile;
        // Enum.GetValuesのキャッシュ。
        private IDPuellaeFormae[] _idFormaeActualis;

        private Ordo<IOrdinatioPuellaeFormae> _queueFormae;
        private bool _estApplicandum;

        public ExecutorPuellaeFormae(
            ITurrisPhantasmaPuellaeFormarum turrisPhantasmaPuellaeFormarum,
            IPhantasmaPuellaeFormarumLegibile phantasmaPuellaeFormarumLegibile,
            IOstiumPuellaeFormaeMutabile ostiumPuellaeFormaeMutabile
        ) {
            _turrisPhantasmaPuellaeFormarum = turrisPhantasmaPuellaeFormarum;
            _phantasmaPuellaeFormarumLegibile = phantasmaPuellaeFormarumLegibile;
            _queueFormae = new Ordo<IOrdinatioPuellaeFormae>(
                ConstansPuellae.LongitudoOrdinatioFormae
            );
            _idFormaeActualis = Enum.GetValues(typeof(IDPuellaeFormae)) as IDPuellaeFormae[];
            _ostiumPuellaeFormaeMutabile = ostiumPuellaeFormaeMutabile;
            _estApplicandum = false;
        }

        public void Initare() {
            _queueFormae.Purgere();
            // 初回適用。シーン開始時、Phantasma にはロード済みの値が入っている前提。
            ApplicareFormae();
        }

        public void Primum() {
            _queueFormae.Purgere();
            _estApplicandum = false;
        }

        public void Executare(
            IOrdinatioPuellaeFormae formae
        ) {
            if (!_queueFormae.ConarePono(formae)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeFormae_MINIATERIUMPUELLAEFORMAE_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Confirmare() {
            while (_queueFormae.ConareLego(out IOrdinatioPuellaeFormae formae)) {
                _turrisPhantasmaPuellaeFormarum.PonoRationem(
                    formae.IdFormae, formae.RatioDesiderata
                );
                _estApplicandum = true;
            }

            // Dirtyフラグが立っている場合、Formaeを適用する。
            if (_estApplicandum) {
                ApplicareFormae();
            }
        }

        public void Purgare() {
            _queueFormae.Purgere();
        }

        private void ApplicareFormae() {
            foreach (IDPuellaeFormae idFormae in _idFormaeActualis) {
                if (idFormae == IDPuellaeFormae.Nihil) {
                    continue;
                }
                _ostiumPuellaeFormaeMutabile.PonoRationem(
                    idFormae,
                    _phantasmaPuellaeFormarumLegibile.RatioActualis(idFormae)
                );
            }
            _estApplicandum = false;
        }
    }
}
