using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorCivisSpectandi : IExecutorCivis {
        private readonly IOstiumCivisSpectandiMutabile _ostiumCivisSpectandiMutabile;

        private Ordo<IOrdinatioCivisSpectandi>[] _queueSpectandi;

        public ExecutorCivisSpectandi(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisSpectandiMutabile ostiumCivisSpectandiMutabile
        ) {
            _ostiumCivisSpectandiMutabile = ostiumCivisSpectandiMutabile;

            _queueSpectandi = new Ordo<IOrdinatioCivisSpectandi>[ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueSpectandi[i] = new Ordo<IOrdinatioCivisSpectandi>(ConstansCivis.LongitudoOrdinatioSpectandi);
            }
        }

        public void Initare(int idCivis) {
            _queueSpectandi[idCivis].Purgere();
        }

        public void Primum(int idCivis) {
            _queueSpectandi[idCivis].Purgere();
        }

        public void Executare(
            int idCivis,
            IOrdinatioCivisSpectandi spectandi
        ) {
            if (!_queueSpectandi[idCivis].ConarePono(spectandi)) {
                Notarius.Memorare(LogTextus.ExecutorCivisSpectandi_EXECUTORCIVISSPECTANDI_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareSpectandi(
            int idCivis,
            IOrdinatioCivisSpectandi spectandi
        ) {
            if (spectandi.EstActivum) {
                _ostiumCivisSpectandiMutabile.Activare(idCivis);
            } else {
                _ostiumCivisSpectandiMutabile.Deactivare(idCivis);
            }
        }

        public void Confirmare(int idCivis) {
            // 最後に投入されたOrdinatioのみ反映する。
            IOrdinatioCivisSpectandi spectandi = null;
            while (_queueSpectandi[idCivis].ConareLego(out var s)) {
                spectandi = s;
            }
            if (spectandi != null) {
                ApplicareSpectandi(idCivis, spectandi);
            }
            _queueSpectandi[idCivis].Purgere();
        }

        public void Purgare(int idCivis) {
            _queueSpectandi[idCivis].Purgere();
        }
    }
}
