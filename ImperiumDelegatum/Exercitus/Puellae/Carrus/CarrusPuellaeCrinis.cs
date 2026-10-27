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

        public void PostulareCrinisAnterior(
            IDPuellaeCrinisCollectionisAnterior idCrinisAnterior
        ){
            if(_lacusOrdinatio.EmittareCrinisAnterior(out var ordinatio)) {
                ordinatio.Pono(idCrinisAnterior);
                _exCrinis.Executare(ordinatio);
            }
        }

        public void PostulareCrinisPosterior(
            IDPuellaeCrinisCollectionisPosterior idCrinisPosterior
        ){
            if(_lacusOrdinatio.EmittareCrinisPosterior(out var ordinatio)) {
                ordinatio.Pono(idCrinisPosterior);
                _exCrinis.Executare(ordinatio);
            }
        }
    }
}
