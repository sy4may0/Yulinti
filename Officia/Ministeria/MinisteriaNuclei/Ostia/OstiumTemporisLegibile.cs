using Yulinti.Officia.Ministeria;
using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumTemporisLegibile : IOstiumTemporisLegibile {

        private readonly ITemporis _temporis;
        public OstiumTemporisLegibile(ITemporis temporis) {
            if (temporis == null) {
                Carnifex.Intermissio(LogTextus.OstiumTemporisLegibile_OSTIUMTEMPORISLEGIBILE_TEMPORIS_NULL);
            }
            _temporis = temporis;
        }

        public float Intervallum => _temporis.Intervallum;
        public float IntervallumFixus => _temporis.IntervallumFixus;
        public int PulsusElapsus => _temporis.PulsusElapsus;
    }
}


