using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeFormae : IExecutorPuellae {
        private ResFluidaPuellaeFormae _resFluidaFormae;

        private Ordo<IOrdinatioPuellaeFormae> _queueFormae;

        public ExecutorPuellaeFormae(
            ResFluidaPuellaeFormae resFluidaFormae
        ) {
            _resFluidaFormae = resFluidaFormae;
            _queueFormae = new Ordo<IOrdinatioPuellaeFormae>(
                ConstansPuellae.LongitudoOrdinatioFormae
            );
        }

        public void Initare() {
            _queueFormae.Purgere();
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
                _resFluidaFormae.RenovareMagnitudoActualis(
                    formae.IdFormae, formae.MagnitudoDesiderata
                );
            }
        }

        public void Purgare() {
            _queueFormae.Purgere();
        }
    }
}