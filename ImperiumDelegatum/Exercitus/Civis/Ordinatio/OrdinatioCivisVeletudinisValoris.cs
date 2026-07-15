namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisValoris : OrdinatioCivis, IOrdinatioCivisVeletudinisValoris {
        private float _dtVitae;
        private float _dtVisus;
        private float _dtVisa;
        private float _dtAuditus;
        private float _dtAudita;
        private float _dtSuspecta;
        private float _dtStudium;

        public OrdinatioCivisVeletudinisValoris(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisValoris) {
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtVisa = 0f;
            _dtAuditus = 0f;
            _dtAudita = 0f;
            _dtSuspecta = 0f;
            _dtStudium = 0f;
        }

        public float DtVitae => _dtVitae;
        public float DtVisus => _dtVisus;
        public float DtVisa => _dtVisa;
        public float DtAuditus => _dtAuditus;
        public float DtAudita => _dtAudita;
        public float DtSuspecta => _dtSuspecta;
        public float DtStudium => _dtStudium;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtVisa = 0f;
            _dtAuditus = 0f;
            _dtAudita = 0f;
            _dtSuspecta = 0f;
            _dtStudium = 0f;
        }

        public void Pono(
            float dtVitae,
            float dtVisus,
            float dtVisa,
            float dtAuditus,
            float dtAudita,
            float dtSuspecta,
            float dtStudium
        ) {
            _estApplicandum = true;
            _dtVitae = dtVitae;
            _dtVisus = dtVisus;
            _dtVisa = dtVisa;
            _dtAuditus = dtAuditus;
            _dtAudita = dtAudita;
            _dtSuspecta = dtSuspecta;
            _dtStudium = dtStudium;
        }
    }
}
