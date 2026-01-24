namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeVeletudinis : OrdinatioPuellae, IOrdinatioPuellaeVeletudinis {
        private float _dtVigoris;
        private float _dtPatientiae;
        private float _dtAetheris;
        private float _dtIntentio;
        private float _dtClaritas;
        private float _dtSonusQuietes;
        private float _dtSonusMotus;

        public OrdinatioPuellaeVeletudinis()
            : base(true, SpeciesOrdinatioPuellae.Veletudinis) {
            _dtVigoris = 0f;
            _dtPatientiae = 0f;
            _dtAetheris = 0f;
            _dtIntentio = 0f;
            _dtClaritas = 0f;
            _dtSonusQuietes = 0f;
            _dtSonusMotus = 0f;
        }

        public float DtVigoris => _dtVigoris;
        public float DtPatientiae => _dtPatientiae;
        public float DtAetheris => _dtAetheris;
        public float DtIntentio => _dtIntentio;
        public float DtClaritas => _dtClaritas;
        public float DtSonusQuietes => _dtSonusQuietes;
        public float DtSonusMotus => _dtSonusMotus;

        public override void Purgere() {
            _estApplicandum = false;
            _dtVigoris = 0f;
            _dtPatientiae = 0f;
            _dtAetheris = 0f;
            _dtIntentio = 0f;
            _dtClaritas = 0f;
            _dtSonusQuietes = 0f;
            _dtSonusMotus = 0f;
        }

        public void Pono(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas,
            float dtSonusQuietes,
            float dtSonusMotus
        ) {
            _dtVigoris = dtVigoris;
            _dtPatientiae = dtPatientiae;
            _dtAetheris = dtAetheris;
            _dtIntentio = dtIntentio;
            _dtClaritas = dtClaritas;
            _dtSonusQuietes = dtSonusQuietes;
            _dtSonusMotus = dtSonusMotus;

            _estApplicandum = true;
        }
    }
}
