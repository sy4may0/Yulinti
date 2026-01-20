using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal interface IOstiumCarrusCivis {
        void PostulareAnimationis(
            int idCivis,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem,
            bool estCogere
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
            float dtAudita = 0f,
            float dtSuspecta = 0f
        );

        void PostulareMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        );

        void PostulareVeletudinisSpectare(
            int idCivis,
            bool estSpectareNudusAnterior,
            bool estSpectareNudusPosterior
        );
    }
}
