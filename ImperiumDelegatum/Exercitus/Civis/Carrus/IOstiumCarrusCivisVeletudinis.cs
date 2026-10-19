using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivisVeletudinis {
        void PostulareVeletudinisValoris(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtAuditus = 0f,
            float dtSuspecta = 0f,
            float dtStudium = 0f,
            float dtIntentio = 0f,
            float dtTorelantiaAnomaliaeMaxima = 0f,
            float dtTorelantiaAnomaliaeMinima = 0f
        );

        void PostulareVeletudinisMaxima(
            int idCivis,
            float dtVitaeMaxima = 0f,
            float dtVisusMaxima = 0f,
            float dtAuditusMaxima = 0f,
            float dtSuspectaMaxima = 0f,
            float dtStudiumMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtTorelantiaAnomaliaeMaximaMaxima = 0f,
            float dtTorelantiaAnomaliaeMinimaMaxima = 0f
        );

        void PostulareVeletudinisCondicionis(
            int idCivis,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        );
    }
}
