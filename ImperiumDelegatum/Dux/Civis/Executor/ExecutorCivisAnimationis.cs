using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorCivisAnimationis : IExecutorCivis {
        private readonly IOstiumCivisLociLegibile _ostiumCivisLociLegibile;
        private readonly IOstiumCivisAnimationesMutabile _ostiumCivisAnimationesMutabile;

        private Ordo<IOrdinatioCivisAnimationis>[] _queueAnimationis;

        public ExecutorCivisAnimationis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisLociLegibile ostiumCivisLociLegibile,
            IOstiumCivisAnimationesMutabile ostiumCivisAnimationesMutabile
        ) {
            _ostiumCivisLociLegibile = ostiumCivisLociLegibile;
            _ostiumCivisAnimationesMutabile = ostiumCivisAnimationesMutabile;

            _queueAnimationis = new Ordo<IOrdinatioCivisAnimationis>[
                ostiumCivisLegibile.Longitudo
            ];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueAnimationis[i] = new Ordo<IOrdinatioCivisAnimationis>(
                    ConstansCivis.LongitudoOrdinatioAnimationis
                );
            }
        }

        public void Initare(int idCivis) {
            foreach (IDCivisAnimationisStratum stratum in System.Enum.GetValues(typeof(IDCivisAnimationisStratum))) {
                _ostiumCivisAnimationesMutabile.Purgere(idCivis, stratum);
            }
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
                Notarius.Memorare(LogTextus.ExecutorCivisAnimationis_EXECUTORCIVISANIMATIONIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareAnimationis(
            int idCivis,
            IOrdinatioCivisAnimationis animationis
        ) {
            _ostiumCivisAnimationesMutabile.Exhibere(idCivis, animationis.Stratum, animationis.IdAnimationis);
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
            foreach (IDCivisAnimationisStratum stratum in System.Enum.GetValues(typeof(IDCivisAnimationisStratum))) {
                _ostiumCivisAnimationesMutabile.Purgere(idCivis, stratum);
            }
            _queueAnimationis[idCivis].Purgere();
        }
    }
}
