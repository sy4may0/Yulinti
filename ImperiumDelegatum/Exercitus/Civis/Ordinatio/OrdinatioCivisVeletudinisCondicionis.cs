using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisCondicionis : OrdinatioCivis, IOrdinatioCivisVeletudinisCondicionis {
        private IDCivisStatusCustodiae? _statusCustodiaeCurrens;

        public OrdinatioCivisVeletudinisCondicionis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisSpectare) {
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }

        public IDCivisStatusCustodiae? StatusCustodiaeCurrens => _statusCustodiaeCurrens;

        public override void Purgere() {
            _estApplicandum = false;
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }
        
        public void Pono(
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            _estApplicandum = true;
            _statusCustodiaeCurrens = statusCustodiaeCurrens;
        }
    }
}
