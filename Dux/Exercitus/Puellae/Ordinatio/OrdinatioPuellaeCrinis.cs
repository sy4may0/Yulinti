using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal readonly class OrdinatioPuellaeCrinis : IOrdinatioPuellaeCrinis {
        private readonly SpeciesOrdinatioPuellae _species = SpeciesOrdinatioPuellae.Apparatus;
        private bool _estApplicandum;

        private IDPuellaeCrinis _idCrinis;

        public OrdinatioPuellaeCrinis() {
            _estApplicandum = true;
            _idCrinis = default;
        }

        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioPuellae Species => _species;
        public IDPuellaeCrinis IdCrinis => _idCrinis;

        public void Purgere() {
            _estApplicandum = false;
            _idCrinis = default;
        }

        public void Pono(
            IDPuellaeCrinis idCrinis
        ) {
            _idCrinis = idCrinis;
            _estApplicandum = true;
        }
    }
}
