namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisMortis : OrdinatioCivis, IOrdinatioCivisMortis {
        private SpeciesOrdinationisCivisMortis _speciesMortis;

        public OrdinatioCivisMortis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisMortis) {
            _speciesMortis = SpeciesOrdinationisCivisMortis.Nihil;
        }

        public SpeciesOrdinationisCivisMortis SpeciesMortis => _speciesMortis;

        public override void Purgere() {
            _estApplicandum = false;
            _speciesMortis = SpeciesOrdinationisCivisMortis.Nihil;
        }

        public void Pono(SpeciesOrdinationisCivisMortis speciesMortis) {
            _estApplicandum = true;
            _speciesMortis = speciesMortis;
        }
    }
}