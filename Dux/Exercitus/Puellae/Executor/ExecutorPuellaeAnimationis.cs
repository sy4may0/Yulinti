using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorPuellaeAnimationis : IExecutorPuellae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IOstiumPuellaeAnimationesMutabile _ostiumPuellaeAnimationesMutabile;

        private DuxQueue<IOrdinatioPuellaeAnimationis> _queueAnimationis;
        private const int _queueAnimationisMaxima = 12;

        public ExecutorPuellaeAnimationis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeAnimationesMutabile ostiumPuellaeAnimationesMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _ostiumPuellaeAnimationesMutabile = ostiumPuellaeAnimationesMutabile;
            _queueAnimationis = new DuxQueue<IOrdinatioPuellaeAnimationis>(_queueAnimationisMaxima);
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
                _contextusOstiorum.Loci.VelocitasHorizontalisActualis()
            );
        }

        public void Purgare() {
            _ostiumPuellaeAnimationesMutabile.Purgere();
            _queueAnimationis.Purgere();
        }
    }
}