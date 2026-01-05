namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisVeletudinisMortis {
        public readonly int IdCivis { get; }
        public readonly bool EstIncarnere { get; }
        public readonly bool EstSpirituare { get; }
        public readonly bool EstMotus { get; }

        public OrdinatioCivisVeletudinisMortis(
            int idCivis,
            bool estIncarnere = false,
            bool estSpirituare = false,
            bool estMotus = false
        ) {
            IdCivis = idCivis;
            EstIncarnere = estIncarnere;
            EstSpirituare = estSpirituare;
            EstMotus = estMotus;
        }
    }
}