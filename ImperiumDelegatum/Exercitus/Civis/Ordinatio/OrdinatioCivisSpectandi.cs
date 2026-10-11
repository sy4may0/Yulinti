namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisSpectandi : OrdinatioCivis, IOrdinatioCivisSpectandi {
        private bool _estActivum;

        public OrdinatioCivisSpectandi(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.ActioSpectandi) {
            _estActivum = false;
        }

        public bool EstActivum => _estActivum;

        public override void Purgere() {
            _estApplicandum = false;
            _estActivum = false;
        }

        public void Pono(bool estActivum) {
            _estApplicandum = true;
            _estActivum = estActivum;
        }
    }
}
