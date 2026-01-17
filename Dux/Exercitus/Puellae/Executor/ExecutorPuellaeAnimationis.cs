using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorPuellaeAnimationis : IExecutorPuellae {
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly IOstiumPuellaeAnimationesMutabile _ostiumPuellaeAnimationesMutabile;

        private DuxQueue<IOrdinatioPuellaeAnimationis> _queueAnimationis;

        public ExecutorPuellaeAnimationis(
            IOstiumPuellaeLociLegibile ostiumPuellaeLociLegibile,
            IOstiumPuellaeAnimationesMutabile ostiumPuellaeAnimationesMutabile
        ) {
            _ostiumPuellaeLociLegibile = ostiumPuellaeLociLegibile;
            _ostiumPuellaeAnimationesMutabile = ostiumPuellaeAnimationesMutabile;
            _queueAnimationis = new DuxQueue<IOrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
        }

        public void Initare() {
            _ostiumPuellaeAnimationesMutabile.Purgere();
            _queueAnimationis.Purgere();
        }

        public void Primum() {
            _queueAnimationis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeAnimationis animationis
        ) {
            if (!_queueAnimationis.ConarePono(animationis)) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAEANIMATION_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareAnimationis(
            IOrdinatioPuellaeAnimationis animationis
        ) {
            if (animationis.EstCogere) {
                _ostiumPuellaeAnimationesMutabile.Cogere(animationis.IdAnimationis, animationis.AdInitium, animationis.AdFinem);
            } else {
                _ostiumPuellaeAnimationesMutabile.Postulare(animationis.IdAnimationis, animationis.AdInitium, animationis.AdFinem);
            }
        }

        public void Confirmare() {
            while (_queueAnimationis.ConareLego(out IOrdinatioPuellaeAnimationis animationis)) {
                ApplicareAnimationis(animationis);
            }
            _ostiumPuellaeAnimationesMutabile.InjicereVelocitatem(
                _ostiumPuellaeLociLegibile.VelocitasHorizontalisActualis()
            );
        }

        public void Purgare() {
            _ostiumPuellaeAnimationesMutabile.Purgere();
            _queueAnimationis.Purgere();
        }
    }
}