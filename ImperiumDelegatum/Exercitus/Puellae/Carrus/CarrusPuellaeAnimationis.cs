using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeAnimationis : IOstiumCarrusPuellaeAnimationis {
        private readonly ExecutorPuellaeAnimationis _exAnimationis;

        private readonly LacusOrdinatioPuellaeAnimationis _lacusOrdinatio;

        public CarrusPuellaeAnimationis(
            ExecutorPuellaeAnimationis exAnimationis
        ) {
            _exAnimationis = exAnimationis;
            _lacusOrdinatio = new LacusOrdinatioPuellaeAnimationis();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareAnimationis(
            IDPuellaeAnimationisStratum stratum,
            IDPuellaeAnimationis idAnimationis
        ){
            if(_lacusOrdinatio.EmittareAnimationis(out var ordinatio)) {
                ordinatio.Pono(stratum, idAnimationis);
                _exAnimationis.Executare(ordinatio);
            }
        }
    }
}
