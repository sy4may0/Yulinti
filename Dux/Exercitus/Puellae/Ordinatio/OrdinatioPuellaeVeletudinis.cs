namespace Yulinti.Dux.Exercitus {
    internal readonly class OrdinatioPuellaeVeletudinis : IOrdinatioPuellaeVeletudinis {
        private readonly SpeciesOrdinatioPuellae _species = SpeciesOrdinatioPuellae.Veletudinis;
        private bool _estApplicandum;

        private float _dtVigoris;
        private float _dtPatientiae;
        private float _dtAetheris;
        private float _dtIntentio;
        private float _dtClaritas;

        public OrdinatioPuellaeVeletudinis() {
            _estApplicandum = true;
            _dtVigoris = 0f;
            _dtPatientiae = 0f;
            _dtAetheris = 0f;
            _dtIntentio = 0f;
            _dtClaritas = 0f;
        }

        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioPuellae Species => _species;
        public float DtVigoris => _dtVigoris;
        public float DtPatientiae => _dtPatientiae;
        public float DtAetheris => _dtAetheris;
        public float DtIntentio => _dtIntentio;
        public float DtClaritas => _dtClaritas;

        public void Purgere() {
            _estApplicandum = false;
            _dtVigoris = 0f;
            _dtPatientiae = 0f;
            _dtAetheris = 0f;
            _dtIntentio = 0f;
            _dtClaritas = 0f;
        }

        public void Pono(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        ) {
            _dtVigoris = dtVigoris;
            _dtPatientiae = dtPatientiae;
            _dtAetheris = dtAetheris;
            _dtIntentio = dtIntentio;
            _dtClaritas = dtClaritas;

            _estApplicandum = true;
        }
    }
}
