using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivis {
        void PostulareAnimationis(
            int idCivis,
            IDCivisAnimationisStratum stratum,
            IDCivisAnimationis idAnimationis
        );

        void PostulareMotus(
            int idCivis,
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        );

        void PostulareNavmesh(
            int idCivis,
            Vector3 positio,
            bool estTransporto,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        );

        void PostulareVeletudinisValoris(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtVisa = 0f,
            float dtAuditus = 0f,
            float dtAudita = 0f,
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
            float dtVisaMaxima = 0f,
            float dtAuditusMaxima = 0f,
            float dtAuditaMaxima = 0f,
            float dtSuspectaMaxima = 0f,
            float dtStudiumMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtTorelantiaAnomaliaeMaximaMaxima = 0f,
            float dtTorelantiaAnomaliaeMinimaMaxima = 0f
        );

        void PostulareMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        );

        void PostulareVeletudinisCondicionis(
            int idCivis,
            bool? estVigilantia = null,
            bool? estDetectio = null,
            bool? estDetectioSonora = null,
            bool? estSuspecta = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        );
    }
}
