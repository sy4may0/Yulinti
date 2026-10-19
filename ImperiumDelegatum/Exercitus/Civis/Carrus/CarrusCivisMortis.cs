using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisMortis : IOstiumCarrusCivisMortis {
        private readonly ExecutorCivisMortis _exMortis;

        private readonly LacusOrdinatioCivisMortis _lacusOrdinatio;

        public CarrusCivisMortis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisMortis exMortis
        ) {
            _exMortis = exMortis;
            _lacusOrdinatio = new LacusOrdinatioCivisMortis(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        ) {
            if (_lacusOrdinatio.EmittareMortis(idCivis, out var ordinatio)) {
                ordinatio.Pono(speciesMortis);
                _exMortis.Executare(idCivis, ordinatio);
            }
        }
    }
}
