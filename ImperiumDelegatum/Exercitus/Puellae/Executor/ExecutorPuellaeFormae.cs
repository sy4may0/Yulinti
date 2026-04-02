using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeFormae : IExecutorPuellae {
        private ResFluidaPuellaeFormae _resFluidaFormae;
        private IOstiumPuellaeFormaeMutabile _ostiumPuellaeFormaeMutabile;
        // Enum.GetValuesのキャッシュ。
        private IDPuellaeFormae[] _idFormaeActualis;

        private Ordo<IOrdinatioPuellaeFormae> _queueFormae;

        public ExecutorPuellaeFormae(
            ResFluidaPuellaeFormae resFluidaFormae
        ) {
            _resFluidaFormae = resFluidaFormae;
            _queueFormae = new Ordo<IOrdinatioPuellaeFormae>(
                ConstansPuellae.LongitudoOrdinatioFormae
            );
            _idFormaeActualis = Enum.GetValues(typeof(IDPuellaeFormae)) as IDPuellaeFormae[];
        }

        public void Initare() {
            _queueFormae.Purgere();
            // 初回適用
            ApplicareFormae();
        }

        public void Primum() {
            _queueFormae.Purgere();
            _resFluidaFormae.ApplicatumEst();
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
                _resFluidaFormae.RenovareRatioActualis(
                    formae.IdFormae, formae.RatioDesiderata
                );
            }

            // Dirtyフラグが立っている場合、Formaeを適用する。
            if (_resFluidaFormae.EstApplicandum) {
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
                _ostiumPuellaeFormaeMutabile.PonoRationem(idFormae, _resFluidaFormae.RatioActualis(idFormae));
            }

        }
    }
}