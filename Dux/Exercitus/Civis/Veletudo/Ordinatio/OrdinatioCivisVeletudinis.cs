namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisVeletudinis {
        public readonly int IdCivis { get; }

        public readonly float DtVitae { get; }
        public readonly bool EstIncarnere { get; }
        public readonly bool EstSpirituare { get; }

        public OrdinatioCivisVeletudinis(
            int idCivis,
            float dtVitae,
            bool estIncarnere = false,
            bool estSpirituare = false
        ) {
            IdCivis = idCivis;
            DtVitae = dtVitae;
            EstIncarnere = estIncarnere;
            EstSpirituare = estSpirituare;
        }
    }
}