namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisVeletudinisMaxima : OrdinatioCivis, IOrdinatioCivisVeletudinisMaxima {
        private float _dtVitaeMaxima;
        private float _dtVisusMaxima;
        private float _dtAuditusMaxima;
        private float _dtSuspectaMaxima;
        private float _dtStudiumMaxima;
        private float _dtIntentioMaxima;
        private float _dtTorelantiaAnomaliaeMaximaMaxima;
        private float _dtTorelantiaAnomaliaeMinimaMaxima;

        public OrdinatioCivisVeletudinisMaxima(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisMaxima) {
            _dtVitaeMaxima = 0f;
            _dtVisusMaxima = 0f;
            _dtAuditusMaxima = 0f;
            _dtSuspectaMaxima = 0f;
            _dtStudiumMaxima = 0f;
            _dtIntentioMaxima = 0f;
            _dtTorelantiaAnomaliaeMaximaMaxima = 0f;
            _dtTorelantiaAnomaliaeMinimaMaxima = 0f;
        }

        public float DtVitaeMaxima => _dtVitaeMaxima;
        public float DtVisusMaxima => _dtVisusMaxima;
        public float DtAuditusMaxima => _dtAuditusMaxima;
        public float DtSuspectaMaxima => _dtSuspectaMaxima;
        public float DtStudiumMaxima => _dtStudiumMaxima;
        public float DtIntentioMaxima => _dtIntentioMaxima;
        public float DtTorelantiaAnomaliaeMaximaMaxima => _dtTorelantiaAnomaliaeMaximaMaxima;
        public float DtTorelantiaAnomaliaeMinimaMaxima => _dtTorelantiaAnomaliaeMinimaMaxima;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVitaeMaxima = 0f;
            _dtVisusMaxima = 0f;
            _dtAuditusMaxima = 0f;
            _dtSuspectaMaxima = 0f;
            _dtStudiumMaxima = 0f;
            _dtIntentioMaxima = 0f;
            _dtTorelantiaAnomaliaeMaximaMaxima = 0f;
            _dtTorelantiaAnomaliaeMinimaMaxima = 0f;
        }

        public void Pono(
            float dtVitaeMaxima,
            float dtVisusMaxima,
            float dtAuditusMaxima,
            float dtSuspectaMaxima,
            float dtStudiumMaxima,
            float dtIntentioMaxima,
            float dtTorelantiaAnomaliaeMaximaMaxima,
            float dtTorelantiaAnomaliaeMinimaMaxima
        ) {
            _dtVitaeMaxima = dtVitaeMaxima;
            _dtVisusMaxima = dtVisusMaxima;
            _dtAuditusMaxima = dtAuditusMaxima;
            _dtSuspectaMaxima = dtSuspectaMaxima;
            _dtStudiumMaxima = dtStudiumMaxima;
            _dtIntentioMaxima = dtIntentioMaxima;
            _dtTorelantiaAnomaliaeMaximaMaxima = dtTorelantiaAnomaliaeMaximaMaxima;
            _dtTorelantiaAnomaliaeMinimaMaxima = dtTorelantiaAnomaliaeMinimaMaxima;

            _estApplicandum = true;
        }
    }
}
