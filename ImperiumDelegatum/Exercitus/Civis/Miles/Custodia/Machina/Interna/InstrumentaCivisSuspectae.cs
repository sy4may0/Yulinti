using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class InstrumentaCivisSuspectae {
        public static float ComputareIncrementumSuspectae(
            int idCivis,
            float incrementumSuspectae,
            float consumptioSuspectae,
            IResFluidaPuellaeVeletudinisLegibile puellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae,
            float limenAnomaliaeSuspectaeNonNudus
        ) {
            if (civisCustodiae.EstVisa(idCivis) && civisCustodiae.EstSpectareNudus(idCivis)) {
                return computareIncrementumNudus(
                    idCivis,
                    incrementumSuspectae,
                    puellaeVeletudinis,
                    civisVeletudinis,
                    civisCustodiae);
            } else if (civisCustodiae.EstVisa(idCivis)) {
                return computareIncrementumVisae(
                    idCivis,
                    incrementumSuspectae,
                    consumptioSuspectae,
                    puellaeVeletudinis,
                    civisVeletudinis,
                    civisCustodiae,
                    limenAnomaliaeSuspectaeNonNudus);
            } else if (civisCustodiae.EstAudita(idCivis)) {
                return computareIncrementumAuditae(
                    idCivis,
                    incrementumSuspectae,
                    puellaeVeletudinis,
                    civisVeletudinis,
                    civisCustodiae);
            } else {
                return -consumptioSuspectae;
            }
        }

        private static float computareIncrementumNudus(
            int idCivis,
            float incrementumSuspectae,
            IResFluidaPuellaeVeletudinisLegibile puellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae
        ) {
            return incrementumSuspectae *
                   civisCustodiae.RatioVisae(idCivis) *
                   puellaeVeletudinis.RatioClaritas *
                   civisVeletudinis.RatioVisus(idCivis);
        }

        private static float computareIncrementumVisae(
            int idCivis,
            float incrementumSuspectae,
            float consumptioSuspectae,
            IResFluidaPuellaeVeletudinisLegibile puellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae,
            float limenAnomaliaeSuspectaeNonNudus
        ) {
            // Anomalia超過チェック
            if (puellaeVeletudinis.Anomalia <= limenAnomaliaeSuspectaeNonNudus) {
                return -consumptioSuspectae;
            }

            return incrementumSuspectae *
                   civisCustodiae.RatioVisae(idCivis) *
                   puellaeVeletudinis.RatioClaritas *
                   civisVeletudinis.RatioVisus(idCivis);
        }

        private static float computareIncrementumAuditae(
            int idCivis,
            float incrementumSuspectae,
            IResFluidaPuellaeVeletudinisLegibile puellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae
        ) {
            return incrementumSuspectae *
                   civisCustodiae.RatioAudita(idCivis) *
                   civisVeletudinis.RatioAuditus(idCivis);
        }

        public static float LimitareSuspectae(
            int idCivis,
            float dtSuspectae,
            float consumptioSuspectae,
            float limitatioSuspectaeAuditae,
            float limitatioSuspectaeNonNudus,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae
        ) {
            if (dtSuspectae <= 0f) {
                return dtSuspectae;
            }

            float limitatio = float.MaxValue;

            if (!civisCustodiae.EstVisa(idCivis) && civisCustodiae.EstAudita(idCivis)) {
                limitatio = limitatioSuspectaeAuditae;
            }

            if (civisCustodiae.EstVisa(idCivis) && !civisCustodiae.EstSpectareNudus(idCivis)) {
                limitatio = limitatioSuspectaeNonNudus;
            }

            float s = civisVeletudinis.Suspecta(idCivis) + dtSuspectae;

            if (s > limitatio) {
                float dtLimitata = limitatio - civisVeletudinis.Suspecta(idCivis);
                // 上限超過済みの場合は通常の消費速度で上限まで減少させる。
                if (dtLimitata < -consumptioSuspectae) {
                    return -consumptioSuspectae;
                }
                return dtLimitata;
            }

            return dtSuspectae;
        }
    }
}