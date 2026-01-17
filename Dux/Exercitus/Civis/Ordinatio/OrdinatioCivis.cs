using System;

namespace Yulinti.Dux.Exercitus {
    internal abstract class OrdinatioCivis : IOrdinatioCivis {
        private readonly int _idCivis;
        private readonly SpeciesOrdinatioCivis _species;
        protected bool _estApplicandum;

        protected OrdinatioCivis(int idCivis, bool estApplicandum, SpeciesOrdinatioCivis species) {
            _idCivis = idCivis;
            _estApplicandum = estApplicandum;
            _species = species;
        }

        public void Initare() {
            _estApplicandum = true;
        }

        public void Liberare() {
            _estApplicandum = false;
        }

        public int IdCivis => _idCivis;
        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioCivis Species => _species;
        public abstract void Purgere();
    }
}