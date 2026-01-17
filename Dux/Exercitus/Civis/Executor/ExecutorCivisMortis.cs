using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorCivisMortis : IExecutorCivis {
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly IOstiumCivisMutabile _ostiumCivisMutabile;

        private DuxQueue<IOrdinatioCivisMortis>[] _queueMortis;

        public ExecutorCivisMortis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisMutabile ostiumCivisMutabile
        ) {
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _ostiumCivisMutabile = ostiumCivisMutabile;
            _queueMortis = new DuxQueue<IOrdinatioCivisMortis>[ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueMortis[i] = new DuxQueue<IOrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);
            }
        }

        public void Initare(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }

        public void PonoAdIncarnare(Action<int> adIncarnare) {
            _ostiumCivisMutabile.PonoAdIncarnare(adIncarnare);
        }

        public void PonoAdSpirituare(Action<int> adSpirituare) {
            _ostiumCivisMutabile.PonoAdSpirituare(adSpirituare);
        }

        public void Primum(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }

        public void Executare(int idCivis, IOrdinatioCivisMortis mortis) {
            if (!_queueMortis[idCivis].ConarePono(mortis)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISMORTIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareMortis(int idCivis) {
            SpeciesOrdinationisCivisMortis currens = SpeciesOrdinationisCivisMortis.Nihil;

            if (_ostiumCivisLegibile.EstActivum(idCivis)) {
                currens = SpeciesOrdinationisCivisMortis.Incarnare;
            } else {
                currens = SpeciesOrdinationisCivisMortis.Spirituare;
            }

            // 適用できるもののみ適用し、かつ1つ適用したら終了する。
            // 実体化時 -> Spirituareのみ適用
            // 非実体化時 -> Incarnareのみ適用
            while (_queueMortis[idCivis].ConareLego(out var m)) {
                if (m.SpeciesMortis == currens) {
                    continue;
                }

                if (m.SpeciesMortis == SpeciesOrdinationisCivisMortis.Spirituare) {
                    _ostiumCivisMutabile.Spirituare(idCivis);
                } else if (m.SpeciesMortis == SpeciesOrdinationisCivisMortis.Incarnare) {
                    _ostiumCivisMutabile.Incarnare(idCivis);
                }
                break;
            }
        }

        public void Confirmare(int idCivis) {
            ApplicareMortis(idCivis);
        }

        public void Purgare(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }
    }
}