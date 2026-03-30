namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaPuellaeVeletudinisLegibile {
        float VigorMaxima { get; }
        float PatientiaMaxima { get; }
        float ClaritasMaxima { get; }
        float AetherMaxima { get; }
        float IntentioMaxima { get; }
        float DedecusMaxima { get; }
        float SonusQuietesMaxima { get; }
        float SonusMotusMaxima { get; }

        float Vigor { get; }
        bool EstExhauritaVigoris { get; }
        float Patientia { get; }
        bool EstExhauritaPatientiae { get; }
        float Claritas { get; }
        float Aether { get; }
        float Intentio { get; }
        float Dedecus { get; }
        float SonusQuietes { get; }
        float SonusMotus { get; }
        bool EstNudusAnterior { get; }
        bool EstNudusPosterior { get; }
    }
}