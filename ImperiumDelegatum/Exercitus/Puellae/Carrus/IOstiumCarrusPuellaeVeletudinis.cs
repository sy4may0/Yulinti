using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellaeVeletudinis {
        void PostulareVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtClaritas = 0f,
            float dtAnomalia = 0f,
            float dtAnomaliaNudus = 0f,
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
    }
}
