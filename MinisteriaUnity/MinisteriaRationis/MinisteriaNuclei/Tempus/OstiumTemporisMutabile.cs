namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumTemporisMutabile : IOstiumTemporisMutabile {
        private readonly FonsTemporis _fonsTemporis;
        public OstiumTemporisMutabile(FonsTemporis fonsTemporis) {
            if (fonsTemporis == null) {
                ModeratorErrorum.Fatal("FonsTemporisのインスタンスがnullです。");
            }
            _fonsTemporis = fonsTemporis;
        }

        public void Pulsus() {
            _fonsTemporis.Pulsus();
        }
        public void PulsusFixus() {
            _fonsTemporis.PulsusFixus();
        }
    }
}