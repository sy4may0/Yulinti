using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisAnimationis : OrdinatioCivis, IOrdinatioCivisAnimationis {
        private IDCivisAnimationisContinuata _idAnimationis;
        private Action _adInitium;
        private Action _adFinem;
        private bool _estCogere;

        public OrdinatioCivisAnimationis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.ActioAnimationis) {
            _idAnimationis = default;
            _adInitium = null;
            _adFinem = null;
            _estCogere = false;
        }

        public IDCivisAnimationisContinuata IdAnimationis => _idAnimationis;
        public Action AdInitium => _adInitium;
        public Action AdFinem => _adFinem;
        public bool EstCogere => _estCogere;

        public override void Purgere() {
            _estApplicandum = false;

            _idAnimationis = default;
            _adInitium = null;
            _adFinem = null;
            _estCogere = false;
        }

        public void Pono(
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ) {
            _estApplicandum = true;

            _idAnimationis = idAnimationis;
            _adInitium = adInitium;
            _adFinem = adFinem;
            _estCogere = estCogere;
        }
    }
}