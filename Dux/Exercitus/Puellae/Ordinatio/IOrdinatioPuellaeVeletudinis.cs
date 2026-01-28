namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeVeletudinis : IOrdinatioPuellae {
        float DtVigoris { get; }
        float DtPatientiae { get; }
        float DtAetheris { get; }
        float DtIntentio { get; }
        float DtDedecus { get; }
        float DtClaritas { get; }
        float DtSonusQuietes { get; }
        float DtSonusMotus { get; }
    }
}