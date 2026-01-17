using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeAnimationis : OrdinatioPuellae, IOrdinatioPuellaeAnimationis {
        private IDPuellaeAnimationisContinuata _idAnimationis;
        private Action _adInitium;
        private Action _adFinem;
        private bool _estCogere;

        public OrdinatioPuellaeAnimationis()
            : base(true, SpeciesOrdinatioPuellae.ActioAnimationis) {
            _idAnimationis = default;
            _adInitium = null;
            _adFinem = null;
            _estCogere = false;
        }

        public IDPuellaeAnimationisContinuata IdAnimationis => _idAnimationis;
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
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ) {
            _idAnimationis = idAnimationis;
            _adInitium = adInitium;
            _adFinem = adFinem;
            _estCogere = estCogere;

            _estApplicandum = true;
        }
    }
}
