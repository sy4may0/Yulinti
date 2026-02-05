using Yulinti.Exercitus.Contractus;
using System;
using System.Numerics;

namespace Yulinti.Exercitus.Dux {
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
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtClaritas = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f
        );

        void PostulareVeletudinisNudi(
            bool estNudusAnterior,
            bool estNudusPosterior
        );

        void PostularePersonae(
            int dtAnimaeLuxuriosus = 0,
            int dtAnimaeExhibitus = 0,
            int dtAnimaePerversus = 0,
            int dtAnimaeQuaeritDolore = 0,
            int dtAnimaePapillae = 0,
            int dtAnimaeLandicae = 0,
            int dtAnimaeVaginae = 0,
            int dtAnimaeAni = 0,
            int dtAnimaeAusculum = 0,
            int dtAnimaeCorporis = 0
        );
    }
}
