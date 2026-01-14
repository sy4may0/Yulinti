namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeVeletudinis : IOrdinatioPuellae {
        float DtVigoris { get; }
        float DtPatientiae { get; }
        float DtAetheris { get; }
        float DtIntentio { get; }
        float DtClaritas { get; }

        void Pono(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        );
    }
}