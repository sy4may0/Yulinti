namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisVeletudinisValoris {
        public readonly int IdCivis { get; }
        public readonly float DtVitae { get; }

        public OrdinatioCivisVeletudinisValoris(
            int idCivis,
            float dtVitae
        ) {
            IdCivis = idCivis;
            DtVitae = dtVitae;
        }
    }
}