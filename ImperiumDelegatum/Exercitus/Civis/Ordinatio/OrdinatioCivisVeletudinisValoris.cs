namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisValoris : OrdinatioCivis, IOrdinatioCivisVeletudinisValoris {
        private float _dtVitae;
        private float _dtVisus;
        private float _dtAuditus;
        private float _dtSuspecta;
        private float _dtStudium;
        private float _dtIntentio;
        private float _dtTorelantiaAnomaliaeMaxima;
        private float _dtTorelantiaAnomaliaeMinima;

        public OrdinatioCivisVeletudinisValoris(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisValoris) {
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtAuditus = 0f;
            _dtSuspecta = 0f;
            _dtStudium = 0f;
            _dtIntentio = 0f;
            _dtTorelantiaAnomaliaeMaxima = 0f;
            _dtTorelantiaAnomaliaeMinima = 0f;
        }

        public float DtVitae => _dtVitae;
        public float DtVisus => _dtVisus;
        public float DtAuditus => _dtAuditus;
        public float DtSuspecta => _dtSuspecta;
        public float DtStudium => _dtStudium;
        public float DtIntentio => _dtIntentio;
        public float DtTorelantiaAnomaliaeMaxima => _dtTorelantiaAnomaliaeMaxima;
        public float DtTorelantiaAnomaliaeMinima => _dtTorelantiaAnomaliaeMinima;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVitae = 0f;
            _dtVisus = 0f;
            _dtAuditus = 0f;
            _dtSuspecta = 0f;
            _dtStudium = 0f;
            _dtIntentio = 0f;
            _dtTorelantiaAnomaliaeMaxima = 0f;
            _dtTorelantiaAnomaliaeMinima = 0f;
        }

        public void Pono(
            float dtVitae,
            float dtVisus,
            float dtAuditus,
            float dtSuspecta,
            float dtStudium,
            float dtIntentio,
            float dtTorelantiaAnomaliaeMaxima,
            float dtTorelantiaAnomaliaeMinima
        ) {
            _estApplicandum = true;
            _dtVitae = dtVitae;
            _dtVisus = dtVisus;
            _dtAuditus = dtAuditus;
            _dtSuspecta = dtSuspecta;
            _dtStudium = dtStudium;
            _dtIntentio = dtIntentio;
            _dtTorelantiaAnomaliaeMaxima = dtTorelantiaAnomaliaeMaxima;
            _dtTorelantiaAnomaliaeMinima = dtTorelantiaAnomaliaeMinima;
        }
    }
}
