using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeFormae : IOstiumCarrusPuellaeFormae {
        private readonly ExecutorPuellaeFormae _exFormae;

        private readonly LacusOrdinatioPuellaeFormae _lacusOrdinatio;

        public CarrusPuellaeFormae(
            ExecutorPuellaeFormae exFormae
        ) {
            _exFormae = exFormae;
            _lacusOrdinatio = new LacusOrdinatioPuellaeFormae();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareFormae(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
        ){
            if(_lacusOrdinatio.EmittareFormae(out var ordinatio)) {
                ordinatio.Pono(idFormae, ratioDesiderata);
                _exFormae.Executare(ordinatio);
            }
        }
    }
}
