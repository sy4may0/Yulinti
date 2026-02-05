using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
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
        public int PulsusElapsus => _temporis.PulsusElapsus;
    }
}


