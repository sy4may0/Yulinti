using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FasciculusOstiorumNuclei {
        private readonly OstiumErrorumLegibile _osErrorumLeg;
        private readonly OstiumTemporisLegibile _osTemporisLeg;

        public FasciculusOstiorumNuclei(ITemporis temporis) {
            _osErrorumLeg = new OstiumErrorumLegibile();
            _osTemporisLeg = new OstiumTemporisLegibile(temporis);
        }

        public IOstiumErrorumLegibile ErrorLeg => _osErrorumLeg;
        public IOstiumTemporisLegibile TempusLeg => _osTemporisLeg;
    }
}