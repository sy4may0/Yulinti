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
            _carrus.PostulareCrinisAnterior(IDPuellaeCrinisCollectionisAnterior.FimbriaLateralis);
            _carrus.PostulareCrinisPosterior(IDPuellaeCrinisCollectionisPosterior.CaudaLateralis);
        }

        public void MutareComam(IDPuellaeCrinisCollectionisAnterior idCrinisAnterior) {
            _carrus.PostulareCrinisAnterior(idCrinisAnterior);
        }

        public void MutareComam(IDPuellaeCrinisCollectionisPosterior idCrinisPosterior) {
            _carrus.PostulareCrinisPosterior(idCrinisPosterior);
        }
    }
}
