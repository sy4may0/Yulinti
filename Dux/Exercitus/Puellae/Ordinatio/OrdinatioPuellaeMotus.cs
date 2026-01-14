namespace Yulinti.Dux.Exercitus {
    internal readonly class OrdinatioPuellaeMotus : IOrdinatioPuellaeMotus {
        private readonly SpeciesOrdinatioPuellae _species = SpeciesOrdinatioPuellae.ActioMotus;
        private bool _estApplicandum;

        private float _velocitasHorizontalis;
        private float _tempusLevigatumHorizontalis;
        private float _rotatioYDeg;
        private float _tempusLevigatumRotationisYDeg;

        public OrdinatioPuellaeMotus() {
            _estApplicandum = true;
            _velocitasHorizontalis = 0f;
            _tempusLevigatumHorizontalis = 0f;
            _rotatioYDeg = 0f;
            _tempusLevigatumRotationisYDeg = 0f;
        }

        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioPuellae Species => _species;
        public float VelocitasHorizontalis => _velocitasHorizontalis;
        public float TempusLevigatumHorizontalis => _tempusLevigatumHorizontalis;
        public float RotatioYDeg => _rotatioYDeg;
        public float TempusLevigatumRotationisYDeg => _tempusLevigatumRotationisYDeg;

        public void Purgere() {
            _estApplicandum = false;
            _velocitasHorizontalis = 0f;
            _tempusLevigatumHorizontalis = 0f;
            _rotatioYDeg = 0f;
            _tempusLevigatumRotationisYDeg = 0f;
        }

        public void Pono(
            float velocitasHorizontalis = 0f,
            float tempusLevigatumHorizontalis = 0f,
            float rotatioYDeg = 0f,
            float tempusLevigatumRotationisYDeg = 0f
        ) {
            _velocitasHorizontalis = velocitasHorizontalis;
            _tempusLevigatumHorizontalis = tempusLevigatumHorizontalis;
            _rotatioYDeg = rotatioYDeg;
            _tempusLevigatumRotationisYDeg = tempusLevigatumRotationisYDeg;

            _estApplicandum = true;
        }
    }
}
