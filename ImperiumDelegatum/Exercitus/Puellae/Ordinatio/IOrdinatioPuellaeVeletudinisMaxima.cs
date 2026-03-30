namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeVeletudinisMaxima : IOrdinatioPuellae {
        float DtVigorMaxima { get; }
        float DtPatientiaeMaxima { get; }
        float DtAetherMaxima { get; }
        float DtClaritasMaxima { get; }
        float DtIntentioMaxima { get; }
        float DtDedecusMaxima { get; }
        float DtSonusQuietesMaxima { get; }
        float DtSonusMotusMaxima { get; }
    }
}
