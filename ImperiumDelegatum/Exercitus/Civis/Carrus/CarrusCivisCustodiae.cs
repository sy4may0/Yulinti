using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisCustodiae : IOstiumCarrusCivisCustodiae {
        private readonly ExecutorCivisCustodiae _exCustodiae;

        private readonly LacusOrdinatioCivisCustodiae _lacusOrdinatio;

        public CarrusCivisCustodiae(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisCustodiae exCustodiae
        ) {
            _exCustodiae = exCustodiae;
            _lacusOrdinatio = new LacusOrdinatioCivisCustodiae(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareCustodiaeDistantia(
            int idCivis,
            float distantiaPuellae,
            bool estCustodiaeVisae,
            bool estCustodiaeAuditae
        ) {
            if (_lacusOrdinatio.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    distantiaPuellae: distantiaPuellae,
                    estCustodiaeVisae: estCustodiaeVisae,
                    estCustodiaeAuditae: estCustodiaeAuditae
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareCustodiaeIctuumVisae(
            int idCivis,
            float visaCapitis,
            float visaCorporis
        ) {
            if (_lacusOrdinatio.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    visaCapitis: visaCapitis,
                    visaCorporis: visaCorporis
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareCustodiaeIctuumAuditae(
            int idCivis,
            float audita
        ) {
            if (_lacusOrdinatio.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    audita: audita
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareSpectareNudus(
            int idCivis,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        ) {
            if (_lacusOrdinatio.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    estSpectareNudusAnterior: estSpectareNudusAnterior,
                    estSpectareNudusPosterior: estSpectareNudusPosterior
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }
    }
}
