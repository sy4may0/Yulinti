using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeCrinis : IOstiumCarrusPuellaeCrinis {
        private readonly ExecutorPuellaeCrinis _exCrinis;

        private readonly LacusOrdinatioPuellaeCrinis _lacusOrdinatio;

        public CarrusPuellaeCrinis(
            ExecutorPuellaeCrinis exCrinis
        ) {
            _exCrinis = exCrinis;
            _lacusOrdinatio = new LacusOrdinatioPuellaeCrinis();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareCrinis(
            IDPuellaeCrinis idCrinis
        ){
            if(_lacusOrdinatio.EmittareCrinis(out var ordinatio)) {
                ordinatio.Pono(idCrinis);
                _exCrinis.Executare(ordinatio);
            }
        }
    }
}
