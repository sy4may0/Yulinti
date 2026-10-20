using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeCrinisBasis : OrdinatioPuellae, IOrdinatioPuellaeCrinisBasis {
        private IDPuellaeCrinisBasis _idCrinisBasis;

        public OrdinatioPuellaeCrinisBasis()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinisBasis = default;
        }

        public IDPuellaeCrinisBasis IdCrinisBasis => _idCrinisBasis;

        public override void Purgere() {
            _estApplicandum = false;
            _idCrinisBasis = default;
        }

        public void Pono(
            IDPuellaeCrinisBasis idCrinisBasis
        ) {
            _idCrinisBasis = idCrinisBasis;
            _estApplicandum = true;
        }
    }

    internal sealed class OrdinatioPuellaeCrinisAnterior : OrdinatioPuellae, IOrdinatioPuellaeCrinisAnterior {
        private IDPuellaeCrinisAnterior _idCrinisAnterior;

        public OrdinatioPuellaeCrinisAnterior()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinisAnterior = default;
        }

        public IDPuellaeCrinisAnterior IdCrinisAnterior => _idCrinisAnterior;

        public override void Purgere() {
            _estApplicandum = false;
            _idCrinisAnterior = default;
        }

        public void Pono(
            IDPuellaeCrinisAnterior idCrinisAnterior
        ) {
            _idCrinisAnterior = idCrinisAnterior;
            _estApplicandum = true;
        }
    }

    internal sealed class OrdinatioPuellaeCrinisPosterior : OrdinatioPuellae, IOrdinatioPuellaeCrinisPosterior {
        private IDPuellaeCrinisPosterior _idCrinisPosterior;

        public OrdinatioPuellaeCrinisPosterior()
            : base(true, SpeciesOrdinatioPuellae.Apparatus) {
            _idCrinisPosterior = default;
        }

        public IDPuellaeCrinisPosterior IdCrinisPosterior => _idCrinisPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _idCrinisPosterior = default;
        }

        public void Pono(
            IDPuellaeCrinisPosterior idCrinisPosterior
        ) {
            _idCrinisPosterior = idCrinisPosterior;
            _estApplicandum = true;
        }
    }
}
