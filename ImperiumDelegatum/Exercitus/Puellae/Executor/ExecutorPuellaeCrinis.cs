using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeCrinis : IExecutorPuellae {
        private readonly IOstiumPuellaeCrinisMutabile _ostiumPuellaeCrinisMutabile;

        private Ordo<IOrdinatioPuellaeCrinisBasis> _queueCrinisBasis;
        private Ordo<IOrdinatioPuellaeCrinisAnterior> _queueCrinisAnterior;
        private Ordo<IOrdinatioPuellaeCrinisPosterior> _queueCrinisPosterior;

        public ExecutorPuellaeCrinis(
            IOstiumPuellaeCrinisMutabile ostiumPuellaeCrinisMutabile
        ) {
            _ostiumPuellaeCrinisMutabile = ostiumPuellaeCrinisMutabile;
            _queueCrinisBasis = new Ordo<IOrdinatioPuellaeCrinisBasis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _queueCrinisAnterior = new Ordo<IOrdinatioPuellaeCrinisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _queueCrinisPosterior = new Ordo<IOrdinatioPuellaeCrinisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public void Initare() {
            _ostiumPuellaeCrinisMutabile.DeletoBasis();
            _ostiumPuellaeCrinisMutabile.DeletoAnterior();
            _ostiumPuellaeCrinisMutabile.DeletoPosterior();
            _queueCrinisBasis.Purgere();
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }

        public void Primum() {
            _queueCrinisBasis.Purgere();
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeCrinisBasis crinisBasis
        ) {
            if (!_queueCrinisBasis.ConarePono(crinisBasis)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_BASIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeCrinisAnterior crinisAnterior
        ) {
            if (!_queueCrinisAnterior.ConarePono(crinisAnterior)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_ANTERIOR_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeCrinisPosterior crinisPosterior
        ) {
            if (!_queueCrinisPosterior.ConarePono(crinisPosterior)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_POSTERIOR_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Confirmare() {
            while (_queueCrinisBasis.ConareLego(out IOrdinatioPuellaeCrinisBasis crinisBasis)) {
                _ostiumPuellaeCrinisMutabile.Muto(crinisBasis.IdCrinisBasis);
            }
            while (_queueCrinisAnterior.ConareLego(out IOrdinatioPuellaeCrinisAnterior crinisAnterior)) {
                _ostiumPuellaeCrinisMutabile.Muto(crinisAnterior.IdCrinisAnterior);
            }
            while (_queueCrinisPosterior.ConareLego(out IOrdinatioPuellaeCrinisPosterior crinisPosterior)) {
                _ostiumPuellaeCrinisMutabile.Muto(crinisPosterior.IdCrinisPosterior);
            }
        }

        public void Purgare() {
            _ostiumPuellaeCrinisMutabile.DeletoBasis();
            _ostiumPuellaeCrinisMutabile.DeletoAnterior();
            _ostiumPuellaeCrinisMutabile.DeletoPosterior();
            _queueCrinisBasis.Purgere();
            _queueCrinisAnterior.Purgere();
            _queueCrinisPosterior.Purgere();
        }
    }
}
