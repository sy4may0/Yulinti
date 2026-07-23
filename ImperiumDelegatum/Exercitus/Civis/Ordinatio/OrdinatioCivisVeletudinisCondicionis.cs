using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisCondicionis : OrdinatioCivis, IOrdinatioCivisVeletudinisCondicionis {
        private bool? _estVigilantia;
        private bool? _estDetectio;
        private bool? _estDetectioSonora;
        private bool? _estSuspecta;
        private bool? _estSpectareNudusAnterior;
        private bool? _estSpectareNudusPosterior;
        private IDCivisStatusCustodiae? _statusCustodiaeCurrens;

        public OrdinatioCivisVeletudinisCondicionis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisSpectare) {
            _estVigilantia = null;
            _estDetectio = null;
            _estDetectioSonora = null;
            _estSuspecta = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }

        public bool? EstVigilantia => _estVigilantia;
        public bool? EstDetectio => _estDetectio;
        public bool? EstDetectioSonora => _estDetectioSonora;
        public bool? EstSuspecta => _estSuspecta;
        public bool? EstSpectareNudusAnterior => _estSpectareNudusAnterior;
        public bool? EstSpectareNudusPosterior => _estSpectareNudusPosterior;
        public IDCivisStatusCustodiae? StatusCustodiaeCurrens => _statusCustodiaeCurrens;

        public override void Purgere() {
            _estApplicandum = false;
            _estVigilantia = null;
            _estDetectio = null;
            _estDetectioSonora = null;
            _estSuspecta = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
            _statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil;
        }
        
        public void Pono(
            bool? estVigilantia = null,
            bool? estDetectio = null,
            bool? estDetectioSonora = null,
            bool? estSuspecta = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            _estApplicandum = true;
            _estVigilantia = estVigilantia;
            _estDetectio = estDetectio;
            _estDetectioSonora = estDetectioSonora;
            _estSuspecta = estSuspecta;
            _estSpectareNudusAnterior = estSpectareNudusAnterior;
            _estSpectareNudusPosterior = estSpectareNudusPosterior;
            _statusCustodiaeCurrens = statusCustodiaeCurrens;
        }
    }
}
