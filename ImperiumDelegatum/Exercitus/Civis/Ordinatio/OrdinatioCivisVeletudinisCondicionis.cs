using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisCondicionis : OrdinatioCivis, IOrdinatioCivisVeletudinisCondicionis {
        private bool? _estSpectareNudusAnterior;
        private bool? _estSpectareNudusPosterior;
        private IDCivisStatusCustodiae? _statusCustodiaeCurrens;

        public OrdinatioCivisVeletudinisCondicionis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisSpectare) {
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }

        public bool? EstSpectareNudusAnterior => _estSpectareNudusAnterior;
        public bool? EstSpectareNudusPosterior => _estSpectareNudusPosterior;
        public IDCivisStatusCustodiae? StatusCustodiaeCurrens => _statusCustodiaeCurrens;

        public override void Purgere() {
            _estApplicandum = false;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }
        
        public void Pono(
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            _estApplicandum = true;
            _estSpectareNudusAnterior = estSpectareNudusAnterior;
            _estSpectareNudusPosterior = estSpectareNudusPosterior;
            _statusCustodiaeCurrens = statusCustodiaeCurrens;
        }
    }
}
