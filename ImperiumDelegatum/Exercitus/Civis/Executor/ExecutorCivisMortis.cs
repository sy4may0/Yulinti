using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using System;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorCivisMortis : IExecutorCivis {
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly IOstiumCivisMutabile _ostiumCivisMutabile;

        private readonly Ordo<IOrdinatioCivisMortis>[] _queueMortis;
        private readonly Ordo<IOrdinatioCivisManifestationis> _queueManifestationis;

        public ExecutorCivisMortis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisMutabile ostiumCivisMutabile
        ) {
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _ostiumCivisMutabile = ostiumCivisMutabile;
            _queueMortis = new Ordo<IOrdinatioCivisMortis>[ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueMortis[i] = new Ordo<IOrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);
            }
            _queueManifestationis = new Ordo<IOrdinatioCivisManifestationis>(
                ConstansCivis.LongitudoOrdinatioManifestationis
            );
        }

        public void Initare(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }

        public void Primum(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }

        public void Executare(int idCivis, IOrdinatioCivisMortis mortis) {
            if (!_queueMortis[idCivis].ConarePono(mortis)) {
                Notarius.Memorare(LogTextus.ExecutorCivisMortis_EXECUTORCIVISMORTIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        public void ExecutareManifestationis(IOrdinatioCivisManifestationis manifestationis) {
            if (!_queueManifestationis.ConarePono(manifestationis)) {
                Notarius.Memorare(LogTextus.ExecutorCivisMortis_EXECUTORCIVISMORTIS_MANIFESTATIONIS_QUEUE_FULL);
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
            // Deletoは実体化状態に依存せず適用する。
            while (_queueMortis[idCivis].ConareLego(out var m)) {
                if (m.SpeciesMortis == currens) {
                    continue;
                }

                if (m.SpeciesMortis == SpeciesOrdinationisCivisMortis.Spirituare) {
                    _ostiumCivisMutabile.Spirituare(idCivis);
                } else if (m.SpeciesMortis == SpeciesOrdinationisCivisMortis.Incarnare) {
                    _ostiumCivisMutabile.Incarnare(idCivis);
                } else if (m.SpeciesMortis == SpeciesOrdinationisCivisMortis.Deleto) {
                    _ostiumCivisMutabile.Deleto(idCivis);
                }
                break;
            }
        }

        private void ApplicareManifestationis() {
            while (_queueManifestationis.ConareLego(out var m)) {
                _ostiumCivisMutabile.Manifestatio(m.IdCivisPersonae);
            }
        }

        public void Confirmare(int idCivis) {
            ApplicareMortis(idCivis);
        }

        public void ConfirmareManifestationis() {
            ApplicareManifestationis();
        }

        public void Purgare(int idCivis) {
            _queueMortis[idCivis].Purgere();
        }

        public void PurgareManifestationis() {
            _queueManifestationis.Purgere();
        }
    }
}
