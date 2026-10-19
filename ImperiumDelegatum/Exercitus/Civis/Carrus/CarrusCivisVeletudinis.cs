using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisVeletudinis : IOstiumCarrusCivisVeletudinis {
        private readonly ExecutorCivisVeletudinis _exVeletudinis;

        private readonly LacusOrdinatioCivisVeletudinis _lacusOrdinatio;

        public CarrusCivisVeletudinis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisVeletudinis exVeletudinis
        ) {
            _exVeletudinis = exVeletudinis;
            _lacusOrdinatio = new LacusOrdinatioCivisVeletudinis(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareVeletudinisValoris(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtAuditus = 0f,
            float dtSuspecta = 0f,
            float dtStudium = 0f,
            float dtIntentio = 0f,
            float dtTorelantiaAnomaliaeMaxima = 0f,
            float dtTorelantiaAnomaliaeMinima = 0f
        ) {
            if (_lacusOrdinatio.EmittareVeletudinisValoris(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    dtVitae, dtVisus, dtAuditus, dtSuspecta, dtStudium,
                    dtIntentio, dtTorelantiaAnomaliaeMaxima, dtTorelantiaAnomaliaeMinima
                );
                _exVeletudinis.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareVeletudinisMaxima(
            int idCivis,
            float dtVitaeMaxima = 0f,
            float dtVisusMaxima = 0f,
            float dtAuditusMaxima = 0f,
            float dtSuspectaMaxima = 0f,
            float dtStudiumMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtTorelantiaAnomaliaeMaximaMaxima = 0f,
            float dtTorelantiaAnomaliaeMinimaMaxima = 0f
        ) {
            if (_lacusOrdinatio.EmittareVeletudinisMaxima(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    dtVitaeMaxima, dtVisusMaxima, dtAuditusMaxima,
                    dtSuspectaMaxima, dtStudiumMaxima, dtIntentioMaxima,
                    dtTorelantiaAnomaliaeMaximaMaxima, dtTorelantiaAnomaliaeMinimaMaxima
                );
                _exVeletudinis.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareVeletudinisCondicionis(
            int idCivis,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            if (_lacusOrdinatio.EmittareVeletudinisCondicionis(idCivis, out var ordinatio)) {
                ordinatio.Pono(statusCustodiaeCurrens);
                _exVeletudinis.Executare(idCivis, ordinatio);
            }
        }
    }
}
