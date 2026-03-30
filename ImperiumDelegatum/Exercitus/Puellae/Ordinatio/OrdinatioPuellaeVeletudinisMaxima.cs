namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeVeletudinisMaxima : OrdinatioPuellae, IOrdinatioPuellaeVeletudinisMaxima {
        private float _dtVigorMaxima;
        private float _dtPatientiaeMaxima;
        private float _dtAetherMaxima;
        private float _dtClaritasMaxima;
        private float _dtIntentioMaxima;
        private float _dtDedecusMaxima;
        private float _dtSonusQuietesMaxima;
        private float _dtSonusMotusMaxima;

        public OrdinatioPuellaeVeletudinisMaxima()
            : base(true, SpeciesOrdinatioPuellae.VeletudinisMaxima) {
            _dtVigorMaxima = 0f;
            _dtPatientiaeMaxima = 0f;
            _dtAetherMaxima = 0f;
            _dtClaritasMaxima = 0f;
            _dtIntentioMaxima = 0f;
            _dtDedecusMaxima = 0f;
            _dtSonusQuietesMaxima = 0f;
            _dtSonusMotusMaxima = 0f;
        }

        public float DtVigorMaxima => _dtVigorMaxima;
        public float DtPatientiaeMaxima => _dtPatientiaeMaxima;
        public float DtAetherMaxima => _dtAetherMaxima;
        public float DtClaritasMaxima => _dtClaritasMaxima;
        public float DtIntentioMaxima => _dtIntentioMaxima;
        public float DtDedecusMaxima => _dtDedecusMaxima;
        public float DtSonusQuietesMaxima => _dtSonusQuietesMaxima;
        public float DtSonusMotusMaxima => _dtSonusMotusMaxima;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVigorMaxima = 0f;
            _dtPatientiaeMaxima = 0f;
            _dtAetherMaxima = 0f;
            _dtClaritasMaxima = 0f;
            _dtIntentioMaxima = 0f;
            _dtDedecusMaxima = 0f;
            _dtSonusQuietesMaxima = 0f;
            _dtSonusMotusMaxima = 0f;
        }

        public void Pono(
            float dtVigorMaxima,
            float dtPatientiaeMaxima,
            float dtAetherMaxima,
            float dtClaritasMaxima,
            float dtIntentioMaxima,
            float dtDedecusMaxima,
            float dtSonusQuietesMaxima,
            float dtSonusMotusMaxima
        ) {
            _dtVigorMaxima = dtVigorMaxima;
            _dtPatientiaeMaxima = dtPatientiaeMaxima;
            _dtAetherMaxima = dtAetherMaxima;
            _dtClaritasMaxima = dtClaritasMaxima;
            _dtIntentioMaxima = dtIntentioMaxima;
            _dtDedecusMaxima = dtDedecusMaxima;
            _dtSonusQuietesMaxima = dtSonusQuietesMaxima;
            _dtSonusMotusMaxima = dtSonusMotusMaxima;

            _estApplicandum = true;
        }
    }
}
