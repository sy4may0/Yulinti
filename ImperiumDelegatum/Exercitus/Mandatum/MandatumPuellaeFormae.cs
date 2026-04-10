using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MandatumPuellaeFormae : IMandatumPuellaeFormae {
        private readonly IOstiumCarrusPuellae _carrus;
        public MandatumPuellaeFormae(
            IOstiumCarrusPuellae carrus
        ) {
            _carrus = carrus;
        }

        public void PostulareFormae(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
        ) {
            _carrus.PostulareFormae(idFormae, ratioDesiderata);
        }
    }
}