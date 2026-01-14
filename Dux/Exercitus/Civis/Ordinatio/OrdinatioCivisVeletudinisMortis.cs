namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisVeletudinisMortis {
        public readonly int IdCivis { get; }
        public readonly bool EstIncarnere { get; }
        public readonly bool EstSpirituare { get; }

        public OrdinatioCivisVeletudinisMortis(
            int idCivis,
            bool estIncarnere = false,
            bool estSpirituare = false
        ) {
            IdCivis = idCivis;
            EstIncarnere = estIncarnere;
            EstSpirituare = estSpirituare;
        }
    }
}