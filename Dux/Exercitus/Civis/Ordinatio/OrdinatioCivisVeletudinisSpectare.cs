namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisSpectare : OrdinatioCivis, IOrdinatioCivisVeletudinisSpectare {
        private bool _estSpectareNudusAnterior;
        private bool _estSpectareNudusPosterior;

        public OrdinatioCivisVeletudinisSpectare(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisSpectare) {
            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }

        public bool EstSpectareNudusAnterior => _estSpectareNudusAnterior;
        public bool EstSpectareNudusPosterior => _estSpectareNudusPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }
        
        public void Pono(
            bool estSpectareNudusAnterior,
            bool estSpectareNudusPosterior
        ) {
            _estApplicandum = true;
            _estSpectareNudusAnterior = estSpectareNudusAnterior;
            _estSpectareNudusPosterior = estSpectareNudusPosterior;
        }
    }
}