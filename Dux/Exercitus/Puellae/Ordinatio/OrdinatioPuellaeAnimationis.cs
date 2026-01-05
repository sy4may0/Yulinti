using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeAnimationis {
        public readonly bool EstApplicandum { get; }
        public readonly IDPuellaeAnimationisContinuata IdAnimationis { get; }
        public readonly Action AdInitium { get; }
        public readonly Action AdFinem { get; }
        public readonly bool EstCogere { get; }

        public OrdinatioPuellaeAnimationis(
            bool estApplicandum,
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ) {
            EstApplicandum = estApplicandum;
            IdAnimationis = idAnimationis;
            AdInitium = adInitium;
            AdFinem = adFinem;
            EstCogere = estCogere;
        }
    }
}