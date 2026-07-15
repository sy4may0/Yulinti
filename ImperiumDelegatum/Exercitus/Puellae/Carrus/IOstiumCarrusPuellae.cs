using Yulinti.ImperiumDelegatum.Contractus;
using System;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellae {
        void PostulareAnimationis(
            IDPuellaeAnimationisStratum stratum,
            IDPuellaeAnimationis idAnimationis
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

        void PostulareNavmeshInitii(
            Vector3 positio,
            Quaternion rotatio
        );

        void PostulareVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtClaritas = 0f,
            float dtAnomalia = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f
        );

        void PostulareVeletudinisMaxima(
            float dtVigorMaxima = 0f,
            float dtPatientiaeMaxima = 0f,
            float dtAetherMaxima = 0f,
            float dtClaritasMaxima = 0f,
            float dtAnomaliaMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtDedecusMaxima = 0f,
            float dtSonusQuietesMaxima = 0f,
            float dtSonusMotusMaxima = 0f
        );

        void PostulareVeletudinisNudi(
            bool estNudusAnterior,
            bool estNudusPosterior
        );

        void PostulareFormae(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
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
