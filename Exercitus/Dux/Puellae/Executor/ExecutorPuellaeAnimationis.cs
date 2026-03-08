using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class ExecutorPuellaeAnimationis : IExecutorPuellae {
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly IOstiumPuellaeAnimationisMutabile _ostiumPuellaeAnimationisMutabile;

        private DuxQueue<IOrdinatioPuellaeAnimationis> _queueAnimationis;

        public ExecutorPuellaeAnimationis(
            IOstiumPuellaeLociLegibile ostiumPuellaeLociLegibile,
            IOstiumPuellaeAnimationisMutabile ostiumPuellaeAnimationisMutabile
        ) {
            _ostiumPuellaeLociLegibile = ostiumPuellaeLociLegibile;
            _ostiumPuellaeAnimationisMutabile = ostiumPuellaeAnimationisMutabile;
            _queueAnimationis = new DuxQueue<IOrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
        }

        public void Initare() {
            _queueAnimationis.Purgere();
        }

        public void Primum() {
            _queueAnimationis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeAnimationis animationis
        ) {
            if (!_queueAnimationis.ConarePono(animationis)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeAnimationis_MINIATERIUMPUELLAEANIMATION_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareAnimationis(
            IOrdinatioPuellaeAnimationis animationis
        ) {
            _ostiumPuellaeAnimationisMutabile.Exhibere(animationis.Stratum, animationis.IdAnimationis);
        }

        public void Confirmare() {
            while (_queueAnimationis.ConareLego(out IOrdinatioPuellaeAnimationis animationis)) {
                ApplicareAnimationis(animationis);
            }
            _ostiumPuellaeAnimationisMutabile.InjicereVelocitatem(
                _ostiumPuellaeLociLegibile.VelocitasHorizontalisActualis()
            );
        }

        public void Purgare() {
            _queueAnimationis.Purgere();
        }
    }
}