using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class ResolutorCivisStatus {
        public static float AugereAuditam(
            float augmentumAuditae,
            float ratio,
            float civisAuditus,
            AbacusTemporis abacusStudiumHabereAuditae,
            float intervallum
        ) {
            return augmentumAuditae * //基礎増加量 
                   ratio * //Ictuumによる距離補正
                   civisAuditus * //Civis聴力
                   abacusStudiumHabereAuditae.ComputareRatio() *
                   intervallum;
        }

        public static float DeminuereAuditam(
            float deminutioAuditae,
            AbacusTemporis abacusStudiumAmittereAuditae,
            float intervallum
        ) {
            return deminutioAuditae * 
                   abacusStudiumAmittereAuditae.ComputareRatio() *
                   intervallum;
        }

        public static float AugereVisae(
            float augmentumVisae,
            float ratio,
            float civisVisus,
            float puellaeClaritas,
            float puellaeAnomalia,
            AbacusTemporis abacusStudiumHabereVisae,
            float intervallum
        ) {
            return augmentumVisae * //基礎増加量 
                   ratio * //Ictuumによる距離/視野角補正
                   civisVisus * //Civis視力
                   puellaeClaritas * //PuellaeステートのClaritas補正
                   puellaeAnomalia * //PuellaeステートのAnomalia補正
                   abacusStudiumHabereVisae.ComputareRatio() *
                   intervallum;
        }

        public static float DeminuereVisae(
            float deminutioVisae,
            AbacusTemporis abacusStudiumAmittereVisae,
            float intervallum
        ) {
            return deminutioVisae * 
                   abacusStudiumAmittereVisae.ComputareRatio() *
                   intervallum;
        }
    }
}