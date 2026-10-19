using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisAnimationis : IOstiumCarrusCivisAnimationis {
        private readonly ExecutorCivisAnimationis _exAnimationis;

        private readonly LacusOrdinatioCivisAnimationis _lacusOrdinatio;

        public CarrusCivisAnimationis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisAnimationis exAnimationis
        ) {
            _exAnimationis = exAnimationis;
            _lacusOrdinatio = new LacusOrdinatioCivisAnimationis(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareAnimationis(int idCivis, IDCivisAnimationisStratum stratum, IDCivisAnimationis idAnimationis) {
            if (_lacusOrdinatio.EmittareAnimationis(idCivis, out var ordinatio)) {
                ordinatio.Pono(stratum, idAnimationis);
                _exAnimationis.Executare(idCivis, ordinatio);
            }
        }
    }
}
