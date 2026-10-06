using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;


namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class InstrumentaCivisIntentionis {
        public static float ComputareIncrementumIntentionis(
            int idCivis,
            float incrementumIntentionis,
            float consumptioIntentionisDefectusAnomaliae,
            float consumptioIntentionisExcessusAnomaliae,
            IResFluidaPuellaeVeletudinisLegibile puellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile civisVeletudinis,
            IResFluidaCivisCustodiaeLegibile civisCustodiae,
            float margoTorelantiaeAnomaliae
        ) {
            // 無条件維持: 視認無し
            // 減少条件: puellaeAnomalia < torelantiaAnomaliaeMinima
            // 維持条件: Intentio = 1
            // 増加条件: Intentio < 1 かつ
            //             torelantiaAnomaliaeMinima <= puellaeAnomalia <= torelantiaAnomaliaeMaxima
            // 無条件減少: puellaeAnomalia > torelantiaAnomaliaeMaxima

            // 減少は、minima/maximaからmargoTorelantiaeの間smoothstepで補正する。離れるほど減少率が大きくなる。

            float torelantiaAnomaliaeMinima = civisVeletudinis.TorelantiaAnomaliaeMinima(idCivis);
            float torelantiaAnomaliaeMaxima = civisVeletudinis.TorelantiaAnomaliaeMaxima(idCivis);

            // Nudus条件はPuellaeを規準とする。Nudus視認していなくてもPuellaeがNudusであればNudusとみなす。
            float anomalia =
                puellaeVeletudinis.EstNudusAnterior || puellaeVeletudinis.EstNudusPosterior
                    ? puellaeVeletudinis.AnomaliaNudus
                    : puellaeVeletudinis.Anomalia;

            if (!civisCustodiae.EstVisa(idCivis)) {
                return 0f;
            }

            if (anomalia < torelantiaAnomaliaeMinima) {
                return ComputareConsumptioDefectusAnomaliae(
                    anomalia,
                    margoTorelantiaeAnomaliae,
                    torelantiaAnomaliaeMinima,
                    consumptioIntentionisDefectusAnomaliae
                );
            }

            if (anomalia > torelantiaAnomaliaeMaxima) {
                return ComputareConsumptioExcessusAnomaliae(
                    anomalia,
                    margoTorelantiaeAnomaliae,
                    torelantiaAnomaliaeMaxima,
                    consumptioIntentionisExcessusAnomaliae
                );
            }

            if (1 - civisVeletudinis.RatioIntentionis(idCivis) <= Numerus.Epsilon) {
                return 0f;
            }

            return incrementumIntentionis;
        }

        private static float ComputareConsumptioDefectusAnomaliae(
            float anomalia,
            float margoTorelantiaeAnomaliae,
            float torelantiaAnomaliaeMinima,
            float consumptioIntentionis
        ) {
            float ratio = 1 - Mathematica.SmoothStep(
                anomalia, 
                torelantiaAnomaliaeMinima - margoTorelantiaeAnomaliae,
                torelantiaAnomaliaeMinima 
            );

            return -consumptioIntentionis * ratio;
        }

        private static float ComputareConsumptioExcessusAnomaliae(
            float anomalia,
            float margoTorelantiaeAnomaliae,
            float torelantiaAnomaliaeMaxima,
            float consumptioIntentionis
        ) {
            float ratio = Mathematica.SmoothStep(
                anomalia,
                torelantiaAnomaliaeMaxima,
                torelantiaAnomaliaeMaxima + margoTorelantiaeAnomaliae
            );

            return -consumptioIntentionis * ratio;
        }
    }
}