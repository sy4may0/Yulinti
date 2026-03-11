namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class OrdinatioPuellaeInitii : IOrdinatioPuellaeInitii {
        private readonly SpeciesOrdinatioPuellae _species;
        protected bool _estApplicandum;

        protected OrdinatioPuellaeInitii(bool estApplicandum, SpeciesOrdinatioPuellae species) {
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
