using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeAnimationis : OrdinatioPuellae, IOrdinatioPuellaeAnimationis {
        private IDPuellaeAnimationisStratum _stratum;
        private IDPuellaeAnimationis _idAnimationis;

        public OrdinatioPuellaeAnimationis()
            : base(true, SpeciesOrdinatioPuellae.ActioAnimationis) {
            _stratum = default;
            _idAnimationis = default;
        }

        public IDPuellaeAnimationisStratum Stratum => _stratum;
        public IDPuellaeAnimationis IdAnimationis => _idAnimationis;

        public override void Purgere() {
            _estApplicandum = false;
            _stratum = default;
            _idAnimationis = default;
        }

        public void Pono(
            IDPuellaeAnimationisStratum stratum,
            IDPuellaeAnimationis idAnimationis
        ) {
            _stratum = stratum;
            _idAnimationis = idAnimationis;

            _estApplicandum = true;
        }
    }
}
