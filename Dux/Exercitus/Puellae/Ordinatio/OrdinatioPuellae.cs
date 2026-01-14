namespace Yulinti.Dux.Exercitus {
    internal abstract class OrdinatioPuellae : IOrdinatioPuellae {
        private readonly SpeciesOrdinatioPuellae _species;
        protected bool _estApplicandum;

        protected OrdinatioPuellae(bool estApplicandum, SpeciesOrdinatioPuellae species) {
            _estApplicandum = estApplicandum;
            _species = species;
        }

        public void Initare() {
            _estApplicandum = true;
        }

        public void Liberare() {
            _estApplicandum = false;
        }

        public SpeciesOrdinatioPuellae Species => _species;
        public bool EstApplicandum => _estApplicandum;
        public abstract void Purgere();
    }
}
