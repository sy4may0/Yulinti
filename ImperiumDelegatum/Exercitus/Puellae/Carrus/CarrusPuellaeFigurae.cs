using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeFigurae : IOstiumCarrusPuellaeFigurae {
        private readonly ExecutorPuellaeFigurae _exFigurae;

        private readonly LacusOrdinatioPuellaeFigurae _lacusOrdinatio;

        public CarrusPuellaeFigurae(
            ExecutorPuellaeFigurae exFigurae
        ) {
            _exFigurae = exFigurae;
            _lacusOrdinatio = new LacusOrdinatioPuellaeFigurae();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        ){
            if(_lacusOrdinatio.EmittareFiguraeGenus(out var ordinatio)) {
                ordinatio.Pono(idFiguraeGenus, latus, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }

        public void PostulareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        ){
            if(_lacusOrdinatio.EmittareFiguraePelvis(out var ordinatio)) {
                ordinatio.Pono(idFiguraePelvis, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }
    }
}
