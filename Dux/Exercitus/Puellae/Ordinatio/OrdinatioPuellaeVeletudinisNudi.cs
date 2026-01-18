namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeVeletudinisNudi : OrdinatioPuellae, IOrdinatioPuellaeVeletudinisNudi {
        private bool _estNudusAnterior;
        private bool _estNudusPosterior;

        public OrdinatioPuellaeVeletudinisNudi()
            : base(true, SpeciesOrdinatioPuellae.VeletudinisNudi) {
            _estNudusAnterior = false;
            _estNudusPosterior = false;
        }

        public bool EstNudusAnterior => _estNudusAnterior;
        public bool EstNudusPosterior => _estNudusPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _estNudusAnterior = false;
            _estNudusPosterior = false;
        }

        public void Pono(bool estNudusAnterior, bool estNudusPosterior) {
            _estApplicandum = true;
            _estNudusAnterior = estNudusAnterior;
            _estNudusPosterior = estNudusPosterior;
        }
    }
}