using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumNuclei {
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