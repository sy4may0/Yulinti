using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal interface IOstiumCarrusPuellae {
        void ExecutareAnimationis(
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem,
            bool estCogere
        );

        void ExecutareCrinis(
            IDPuellaeCrinis idCrinis
        );

        void ExecutareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        );

        void ExecutareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        );

        void ExecutareMotus(
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        );

        void ExecutareNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        );

        void ExecutareVeletudinis(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        );
    }
}