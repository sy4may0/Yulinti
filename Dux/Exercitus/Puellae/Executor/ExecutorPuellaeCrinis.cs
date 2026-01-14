using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorPuellaeCrinis : IExecutorPuellae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _ostiumPuellaeCrinisAdiunctionisMutabile;

        private DuxQueue<IOrdinatioPuellaeCrinis> _queueCrinis;
        private const int _queueCrinisMaxima = 6;

        public ExecutorPuellaeCrinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeCrinisAdiunctionisMutabile ostiumPuellaeCrinisAdiunctionisMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _ostiumPuellaeCrinisAdiunctionisMutabile = ostiumPuellaeCrinisAdiunctionisMutabile;
            _queueCrinis = new DuxQueue<IOrdinatioPuellaeCrinis>(_queueCrinisMaxima);
        }

        public void Primum() {
            _queueCrinis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeCrinis crinis
        ) {
            if (!_queueCrinis.ConarePono(crinis)) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAECRINIS_ORDINATIO_QUEUE_FULL);
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