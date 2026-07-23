namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeVeletudinis : IOrdinatioPuellae {
        float DtVigoris { get; }
        float DtPatientiae { get; }
        float DtAetheris { get; }
        float DtIntentio { get; }
        float DtDedecus { get; }
        float DtClaritas { get; }
        float DtAnomalia { get; }
        float DtAnomaliaNudus { get; }
        float DtSonusQuietes { get; }
        float DtSonusMotus { get; }
    }
}
