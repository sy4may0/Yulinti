using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeCrinisCollectionisAnterior : OrdinatioPuellae, IOrdinatioPuellaeCrinisCollectionisAnterior {
        private IDPuellaeCrinisCollectionisAnterior _idCrinisCollectionisAnterior;

        public OrdinatioPuellaeCrinisCollectionisAnterior()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinisCollectionisAnterior = default;
        }

        public IDPuellaeCrinisCollectionisAnterior IdCrinisCollectionisAnterior => _idCrinisCollectionisAnterior;

        public override void Purgere() {
            _estApplicandum = false;
            _idCrinisCollectionisAnterior = default;
        }

        public void Pono(
            IDPuellaeCrinisCollectionisAnterior idCrinisCollectionisAnterior
        ) {
            _idCrinisCollectionisAnterior = idCrinisCollectionisAnterior;
            _estApplicandum = true;
        }
    }

    internal sealed class OrdinatioPuellaeCrinisCollectionisPosterior : OrdinatioPuellae, IOrdinatioPuellaeCrinisCollectionisPosterior {
        private IDPuellaeCrinisCollectionisPosterior _idCrinisCollectionisPosterior;

        public OrdinatioPuellaeCrinisCollectionisPosterior()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinisCollectionisPosterior = default;
        }

        public IDPuellaeCrinisCollectionisPosterior IdCrinisCollectionisPosterior => _idCrinisCollectionisPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _idCrinisCollectionisPosterior = default;
        }

        public void Pono(
            IDPuellaeCrinisCollectionisPosterior idCrinisCollectionisPosterior
        ) {
            _idCrinisCollectionisPosterior = idCrinisCollectionisPosterior;
            _estApplicandum = true;
        }
    }
}
