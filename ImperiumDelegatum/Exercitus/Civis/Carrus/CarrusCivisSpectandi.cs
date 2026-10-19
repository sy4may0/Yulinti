using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisSpectandi : IOstiumCarrusCivisSpectandi {
        private readonly ExecutorCivisSpectandi _exSpectandi;

        private readonly LacusOrdinatioCivisSpectandi _lacusOrdinatio;

        public CarrusCivisSpectandi(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisSpectandi exSpectandi
        ) {
            _exSpectandi = exSpectandi;
            _lacusOrdinatio = new LacusOrdinatioCivisSpectandi(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareSpectandi(
            int idCivis,
            bool estActivum
        ) {
            if (_lacusOrdinatio.EmittareSpectandi(idCivis, out var ordinatio)) {
                ordinatio.Pono(estActivum);
                _exSpectandi.Executare(idCivis, ordinatio);
            }
        }
    }
}
