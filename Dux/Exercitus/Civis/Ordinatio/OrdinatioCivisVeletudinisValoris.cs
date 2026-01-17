namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisValoris : OrdinatioCivis, IOrdinatioCivisVeletudinisValoris {
        private float _dtVitae;
        private float _dtVisus;
        private float _dtVisa;
        private float _dtAudita;
        private float _dtSuspecta;

        public OrdinatioCivisVeletudinisValoris(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisValoris) {
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtVisa = 0f;
            _dtAudita = 0f;
            _dtSuspecta = 0f;
        }

        public float DtVitae => _dtVitae;
        public float DtVisus => _dtVisus;
        public float DtVisa => _dtVisa;
        public float DtAudita => _dtAudita;
        public float DtSuspecta => _dtSuspecta;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtVisa = 0f;
            _dtAudita = 0f;
            _dtSuspecta = 0f;
        }

        public void Pono(
            float dtVitae,
            float dtVisus,
            float dtVisa,
            float dtAudita,
            float dtSuspecta
        ) {
            _estApplicandum = true;
            _dtVitae = dtVitae;
            _dtVisus = dtVisus;
            _dtVisa = dtVisa;
            _dtAudita = dtAudita;
            _dtSuspecta = dtSuspecta;

        }
    }
}