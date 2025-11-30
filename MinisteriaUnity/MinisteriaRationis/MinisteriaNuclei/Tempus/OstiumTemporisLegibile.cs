using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumTemporisLegibile : IOstiumTemporisLegibile {

        private readonly ITemporis _temporis;
        public OstiumTemporisLegibile(ITemporis temporis) {
            if (temporis == null) {
                Errorum.Fatal(IDErrorum.OSTIUMTEMPORISLEGIBILE_TEMPORIS_NULL);
            }
            _temporis = temporis;
        }

        public float Intervallum => _temporis.Intervallum;
        public float IntervallumFixus => _temporis.IntervallumFixus;
    }
}


