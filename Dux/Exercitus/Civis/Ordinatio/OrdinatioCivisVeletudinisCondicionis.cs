namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisCondicionis : OrdinatioCivis, IOrdinatioCivisVeletudinisCondicionis {
        private bool? _estVigilantia;
        private bool? _estDetectio;
        private bool? _estAudivi;
        private bool? _estSuspecta;
        private bool? _estSpectareNudusAnterior;
        private bool? _estSpectareNudusPosterior;

        public OrdinatioCivisVeletudinisCondicionis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisSpectare) {
            _estVigilantia = null;
            _estDetectio = null;
            _estAudivi = null;
            _estSuspecta = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
        }

        public bool? EstVigilantia => _estVigilantia;
        public bool? EstDetectio => _estDetectio;
        public bool? EstAudivi => _estAudivi;
        public bool? EstSuspecta => _estSuspecta;
        public bool? EstSpectareNudusAnterior => _estSpectareNudusAnterior;
        public bool? EstSpectareNudusPosterior => _estSpectareNudusPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _estVigilantia = null;
            _estDetectio = null;
            _estAudivi = null;
            _estSuspecta = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
        }
        
        public void Pono(
            bool? estVigilantia = null,
            bool? estDetectio = null,
            bool? estAudivi = null,
            bool? estSuspecta = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        ) {
            _estApplicandum = true;
            _estVigilantia = estVigilantia;
            _estDetectio = estDetectio;
            _estAudivi = estAudivi;
            _estSuspecta = estSuspecta;
            _estSpectareNudusAnterior = estSpectareNudusAnterior;
            _estSpectareNudusPosterior = estSpectareNudusPosterior;
        }
    }
}
