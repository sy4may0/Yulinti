using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeCrinis {
        private readonly IOstiumCarrusPuellae _carrus;

        // VContainer注入
        public MilesPuellaeCrinis(
            IOstiumCarrusPuellae carrus
        ) {
            _carrus = carrus;
        }

        public void Initare() {
            // Default Hair
            _carrus.PostulareCrinis(IDPuellaeCrinis.Resiliens);
        }

        public void MutareComam(IDPuellaeCrinis idCrinis) {
            _carrus.PostulareCrinis(idCrinis);
        }
    }
}