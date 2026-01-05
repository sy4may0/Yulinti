using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisAnimationis {
        public readonly bool EstApplicandum { get; }
        public readonly IDCivisAnimationisContinuata IdAnimationis { get; }
        public readonly Action AdInitium { get; }
        public readonly Action AdFinem { get; }
        public readonly bool EstCogere { get; }
        private readonly int _idCivis;

        public OrdinatioCivisAnimationis(
            int idCivis,
            bool estApplicandum,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ) {
            _idCivis = idCivis;
            EstApplicandum = estApplicandum;
            IdAnimationis = idAnimationis;
            AdInitium = adInitium;
            AdFinem = adFinem;
            EstCogere = estCogere;
        }

        public int IdCivis {
            get {
                return _idCivis;
            }
        }
    }
}
