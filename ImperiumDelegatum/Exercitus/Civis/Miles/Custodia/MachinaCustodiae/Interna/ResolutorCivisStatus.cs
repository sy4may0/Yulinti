using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class ResolutorCivisStatus {
        // 視覚刺激によるSuspecta増加量。
        public static float AugereSuspectaeVisae(
            float augmentumSuspectae,
            float ratio,
            float civisVisus,
            float puellaeClaritas,
            AbacusTemporis abacusStudiumHabereSuspectae,
            float intervallum
        ) {
            return augmentumSuspectae * //基礎増加量 
                   ratio * //Ictuumによる距離/視野角補正
                   civisVisus * //Civis視力
                   puellaeClaritas * //PuellaeステートのClaritas補正
                   abacusStudiumHabereSuspectae.ComputareRatio() *
                   intervallum;
        }

        // 聴覚刺激によるSuspecta増加量。
        public static float AugereSuspectaeAuditae(
            float augmentumSuspectae,
            float ratio,
            float civisAuditus,
            AbacusTemporis abacusStudiumHabereSuspectae,
            float intervallum
        ) {
            return augmentumSuspectae * //基礎増加量 
                   ratio * //Ictuumによる距離補正
                   civisAuditus * //Civis聴力
                   abacusStudiumHabereSuspectae.ComputareRatio() *
                   intervallum;
        }

        public static float DeminuereSuspectam(
            float deminutioSuspectae,
            AbacusTemporis abacusStudiumAmittereSuspectae,
            float intervallum
        ) {
            return deminutioSuspectae * 
                   abacusStudiumAmittereSuspectae.ComputareRatio() *
                   intervallum;
        }

        public static float ResolvereTorelantiamAnomaliae(
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima,
            float anomalia
        ) {
            float centrum = (torelantiaAnomaliaeMaxima + torelantiaAnomaliaeMinima) / 2f;
            if (anomalia < torelantiaAnomaliaeMinima || anomalia > torelantiaAnomaliaeMaxima) {
                return 0f;
            }
            if (anomalia <= centrum) {
                return Mathematica.SmoothStep(
                    anomalia,
                    torelantiaAnomaliaeMinima,
                    centrum
                );
            }

            return 1f;
        }

        public static float AugereStudiumIntuitus(
            float augmentumStudium,
            float puellaeAnomalia,
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima,
            AbacusTemporis abacusStudiumHabereStudii,
            float intervallum
        ) {
            return augmentumStudium * 
                   puellaeAnomalia * 
                   ResolvereTorelantiamAnomaliae(
                    torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima,
                    puellaeAnomalia
                   ) *
                   abacusStudiumHabereStudii.ComputareRatio() *
                   intervallum;
        }

        public static float DeminuereStudiumIntuitus(
            float deminutioStudium,
            AbacusTemporis abacusStudiumAmittereStudii,
            float intervallum
        ) {
            return deminutioStudium * 
                   abacusStudiumAmittereStudii.ComputareRatio() *
                   intervallum;
        }

        public static float AugereIntentionisIntuitus(
            float augmentumIntentionis,
            float ratio, //Ictuumによる距離/視野角補正
            float puellaeAnomalia,
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima,
            AbacusTemporis abacusStudiumHabereIntentionis,
            float intervallum
        ) {
            return augmentumIntentionis * 
                   ratio * 
                   puellaeAnomalia * 
                   ResolvereTorelantiamAnomaliae(
                    torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima,
                    puellaeAnomalia
                   ) *
                   abacusStudiumHabereIntentionis.ComputareRatio() *
                   intervallum;
        }

        public static float DeminuereIntentionisIntuitus(
            float deminutioIntentionis,
            AbacusTemporis abacusStudiumAmittereIntentionis,
            float intervallum
        ) {
            return deminutioIntentionis * 
                   abacusStudiumAmittereIntentionis.ComputareRatio() *
                   intervallum;
        }

        // 補正Anomaliae
        public static float CorrigereAnomaliae(
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            int idCivis
        ) {
            if (resFluidaCivisVeletudinis.EstSpectareNudus(idCivis)) {
                return resFluidaPuellaeVeletudinis.AnomaliaNudus;
            }
            return resFluidaPuellaeVeletudinis.Anomalia;
        }

        public static float CorrigereRatioAnomaliae(
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            int idCivis
        ) {
            if (resFluidaCivisVeletudinis.EstSpectareNudus(idCivis)) {
                return resFluidaPuellaeVeletudinis.RatioAnomaliaeNudus;
            }
            return resFluidaPuellaeVeletudinis.RatioAnomaliae;
        }
    }
}