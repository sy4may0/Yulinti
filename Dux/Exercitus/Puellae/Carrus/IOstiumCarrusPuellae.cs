using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal interface IOstiumCarrusPuellae {
        void PostulareAnimationis(
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem,
            bool estCogere
        );

        void PostulareCrinis(
            IDPuellaeCrinis idCrinis
        );

        void PostulareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        );

        void PostulareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        );

        void PostulareMotus(
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        );

        void PostulareNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        );

        void PostulareVeletudinis(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        );
    }
}