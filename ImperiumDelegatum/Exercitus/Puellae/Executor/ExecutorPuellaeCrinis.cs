using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeCrinis : IExecutorPuellae {
        private readonly IOstiumPuellaeCrinisMutabile _ostiumPuellaeCrinisMutabile;

        private Ordo<IOrdinatioPuellaeCrinisCollectionisAnterior> _queueCrinisAnterior;
        private Ordo<IOrdinatioPuellaeCrinisCollectionisPosterior> _queueCrinisPosterior;

        public ExecutorPuellaeCrinis(
            IOstiumPuellaeCrinisMutabile ostiumPuellaeCrinisMutabile
        ) {
            _ostiumPuellaeCrinisMutabile = ostiumPuellaeCrinisMutabile;
            _queueCrinisAnterior = new Ordo<IOrdinatioPuellaeCrinisCollectionisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _queueCrinisPosterior = new Ordo<IOrdinatioPuellaeCrinisCollectionisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public void Initare() {
            _ostiumPuellaeCrinisMutabile.DeletoAnterior();
            _ostiumPuellaeCrinisMutabile.DeletoPosterior();
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }

        public void Primum() {
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeCrinisCollectionisAnterior crinisAnterior
        ) {
            if (!_queueCrinisAnterior.ConarePono(crinisAnterior)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_ANTERIOR_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeCrinisCollectionisPosterior crinisPosterior
        ) {
            if (!_queueCrinisPosterior.ConarePono(crinisPosterior)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_POSTERIOR_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Confirmare() {
            while (_queueCrinisAnterior.ConareLego(out IOrdinatioPuellaeCrinisCollectionisAnterior crinisAnterior)) {
                _ostiumPuellaeCrinisMutabile.Muto(crinisAnterior.IdCrinisCollectionisAnterior);
            }
            while (_queueCrinisPosterior.ConareLego(out IOrdinatioPuellaeCrinisCollectionisPosterior crinisPosterior)) {
                _ostiumPuellaeCrinisMutabile.Muto(crinisPosterior.IdCrinisCollectionisPosterior);
            }
        }

        public void Purgare() {
            _ostiumPuellaeCrinisMutabile.DeletoAnterior();
            _ostiumPuellaeCrinisMutabile.DeletoPosterior();
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }
    }
}
