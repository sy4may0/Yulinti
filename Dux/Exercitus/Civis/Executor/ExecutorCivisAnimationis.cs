using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorCivisAnimationis : IExecutorCivis {
        private readonly IOstiumCivisLociLegibile _ostiumCivisLociLegibile;
        private readonly IOstiumCivisAnimationesMutabile _ostiumCivisAnimationesMutabile;

        private DuxQueue<IOrdinatioCivisAnimationis>[] _queueAnimationis;

        public ExecutorCivisAnimationis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisLociLegibile ostiumCivisLociLegibile,
            IOstiumCivisAnimationesMutabile ostiumCivisAnimationesMutabile
        ) {
            _ostiumCivisLociLegibile = ostiumCivisLociLegibile;
            _ostiumCivisAnimationesMutabile = ostiumCivisAnimationesMutabile;

            _queueAnimationis = new DuxQueue<IOrdinatioCivisAnimationis>[
                ostiumCivisLegibile.Longitudo
            ];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueAnimationis[i] = new DuxQueue<IOrdinatioCivisAnimationis>(
                    ConstansCivis.LongitudoOrdinatioAnimationis
                );
            }
        }

        public void Initare(int idCivis) {
            _ostiumCivisAnimationesMutabile.Purgere(idCivis);
            _queueAnimationis[idCivis].Purgere();
        }

        public void Primum(int idCivis) {
            _queueAnimationis[idCivis].Purgere();
        }

        public void Executare(
            int idCivis,
            IOrdinatioCivisAnimationis animationis
        ) {
            if (!_queueAnimationis[idCivis].ConarePono(animationis)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISANIMATIONIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareAnimationis(
            int idCivis,
            IOrdinatioCivisAnimationis animationis
        ) {
            if (animationis.EstCogere) {
                _ostiumCivisAnimationesMutabile.Cogere(idCivis, animationis.IdAnimationis, animationis.AdInitium, animationis.AdFinem);
            } else {
                _ostiumCivisAnimationesMutabile.Postulare(idCivis, animationis.IdAnimationis, animationis.AdInitium, animationis.AdFinem);
            }
        }

        public void Confirmare(int idCivis) {
            while (_queueAnimationis[idCivis].ConareLego(out IOrdinatioCivisAnimationis animationis)) {
                ApplicareAnimationis(idCivis, animationis);
            }
            _ostiumCivisAnimationesMutabile.InjicereVelocitatem(
                idCivis,
                _ostiumCivisLociLegibile.VelocitasHorizontalisActualis(idCivis)
            );
        }

        public void Purgare(int idCivis) {
            _ostiumCivisAnimationesMutabile.Purgere(idCivis);
            _queueAnimationis[idCivis].Purgere();
        }
    }
}