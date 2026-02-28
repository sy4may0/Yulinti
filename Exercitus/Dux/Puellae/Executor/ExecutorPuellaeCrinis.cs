using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class ExecutorPuellaeCrinis : IExecutorPuellae {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _ostiumPuellaeCrinisAdiunctionisMutabile;

        private DuxQueue<IOrdinatioPuellaeCrinis> _queueCrinis;

        public ExecutorPuellaeCrinis(
            IOstiumPuellaeCrinisAdiunctionisMutabile ostiumPuellaeCrinisAdiunctionisMutabile
        ) {
            _ostiumPuellaeCrinisAdiunctionisMutabile = ostiumPuellaeCrinisAdiunctionisMutabile;
            _queueCrinis = new DuxQueue<IOrdinatioPuellaeCrinis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public void Initare() {
            _ostiumPuellaeCrinisAdiunctionisMutabile.Deleto();
            _queueCrinis.Purgere();
        }

        public void Primum() {
            _queueCrinis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeCrinis crinis
        ) {
            if (!_queueCrinis.ConarePono(crinis)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeCrinis_MINIATERIUMPUELLAECRINIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void Confirmare() {
            while (_queueCrinis.ConareLego(out IOrdinatioPuellaeCrinis crinis)) {
                _ostiumPuellaeCrinisAdiunctionisMutabile.Muto(crinis.IdCrinis);
            }
        }

        public void Purgare() {
            _ostiumPuellaeCrinisAdiunctionisMutabile.Deleto();
            _queueCrinis.Purgere();
        }

    }
}