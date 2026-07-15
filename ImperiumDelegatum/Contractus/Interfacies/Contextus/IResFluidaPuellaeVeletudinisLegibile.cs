namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaPuellaeVeletudinisLegibile {
        float VigorMaxima { get; }
        float PatientiaMaxima { get; }
        float ClaritasMaxima { get; }
        float AnomaliaMaxima { get; }
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
        float Anomalia { get; }
        float Aether { get; }
        float Intentio { get; }
        float Dedecus { get; }
        float SonusQuietes { get; }
        float SonusMotus { get; }
        bool EstNudusAnterior { get; }
        bool EstNudusPosterior { get; }

        float RatioVigoris { get; }
        float RatioPatientiae { get; }
        float RatioClaritas { get; }
        float RatioAnomaliae { get; }
        float RatioAether { get; }
        float RatioIntentionis { get; }
        float RatioDedecus { get; }
        float RatioSonusQuietes { get; }
        float RatioSonusMotus { get; }
    }
}
