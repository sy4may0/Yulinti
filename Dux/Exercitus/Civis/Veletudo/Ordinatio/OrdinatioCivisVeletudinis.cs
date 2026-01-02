namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisVeletudinis {
        public readonly int IdCivis { get; }
        public readonly int DtVitae { get; }

        public OrdinatioCivisVeletudinis(
            int idCivis,
            int dtVitae
        ) {
            IdCivis = idCivis;
            DtVitae = dtVitae;
        }
    }
}