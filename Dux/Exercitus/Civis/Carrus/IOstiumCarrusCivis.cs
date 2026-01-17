using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal interface IOstiumCarrusCivis {
        void ExecutareAnimationis(
            int idCivis,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem,
            bool estCogere
        );

        void ExecutareMotus(
            int idCivis,
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        );

        void ExecutareNavmesh(
            int idCivis,
            Vector3 positio,
            bool estTransporto,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        );

        void ExecutareVeletudinisValoris(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtVisa = 0f,
            float dtAudita = 0f,
            float dtSuspecta = 0f
        );

        void ExecutareVeletudinisMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        );
    }
}
