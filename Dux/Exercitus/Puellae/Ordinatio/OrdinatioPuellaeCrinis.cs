using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeCrinis : OrdinatioPuellae, IOrdinatioPuellaeCrinis {
        private IDPuellaeCrinis _idCrinis;

        public OrdinatioPuellaeCrinis()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinis = default;
        }

        public IDPuellaeCrinis IdCrinis => _idCrinis;

        public override void Purgere() {
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
