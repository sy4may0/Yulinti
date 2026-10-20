using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeCrinis {
        private readonly IOstiumCarrusPuellaeCrinis _carrus;

        // VContainer注入
        public MilesPuellaeCrinis(
            IOstiumCarrusPuellaeCrinis carrus
        ) {
            _carrus = carrus;
        }

        public void Initare() {
            // Default Hair
            _carrus.PostulareCrinisBasis(IDPuellaeCrinisBasis.NodusLateralis);
            _carrus.PostulareCrinisPosterior(IDPuellaeCrinisPosterior.CaudaLateralis);
            _carrus.PostulareCrinisAnterior(IDPuellaeCrinisAnterior.FimbriaLateralis);
        }

        public void MutareComam(IDPuellaeCrinisBasis idCrinisBasis) {
            _carrus.PostulareCrinisBasis(idCrinisBasis);
        }

        public void MutareComam(IDPuellaeCrinisAnterior idCrinisAnterior) {
            _carrus.PostulareCrinisAnterior(idCrinisAnterior);
        }

        public void MutareComam(IDPuellaeCrinisPosterior idCrinisPosterior) {
            _carrus.PostulareCrinisPosterior(idCrinisPosterior);
        }
    }
}
