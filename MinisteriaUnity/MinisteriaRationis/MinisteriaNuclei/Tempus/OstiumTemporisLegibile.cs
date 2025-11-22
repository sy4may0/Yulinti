using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumTemporisLegibile : IOstiumTemporisLegibile {

        private readonly ITemporis _temporis;
        public OstiumTemporisLegibile(ITemporis temporis) {
            if (temporis == null) {
                ModeratorErrorum.Fatal("OstiumTemporisLegibileのTemporisがnullです。");
            }
            _temporis = temporis;
        }

        public float Intervallum => _temporis.Intervallum;
        public float IntervallumFixus => _temporis.IntervallumFixus;
    }
}