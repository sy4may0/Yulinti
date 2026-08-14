using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class CarrusCivisManifestationis : IOstiumCarrusCivisManifestationis {
        private readonly ExecutorCivisMortis _exMortis;
        private readonly LacusOrdinatioCivisManifestationis _lacusOrdinatioCivisManifestationis;

        public CarrusCivisManifestationis(
            ExecutorCivisMortis exMortis
        ) {
            _exMortis = exMortis;
            _lacusOrdinatioCivisManifestationis = new LacusOrdinatioCivisManifestationis();
        }

        public void Confirmare() {
            _exMortis.ConfirmareManifestationis();
            _lacusOrdinatioCivisManifestationis.Colligere();
        }

        public void Purgare() {
            _exMortis.PurgareManifestationis();
            _lacusOrdinatioCivisManifestationis.Colligere();
        }

        public void PostulareManifestationis(IDCivisPersonae idCivisPersonae) {
            if (_lacusOrdinatioCivisManifestationis.Emittare(out var ordinatio)) {
                ordinatio.Pono(idCivisPersonae);
                _exMortis.ExecutareManifestationis(ordinatio);
            }
        }
    }
}
