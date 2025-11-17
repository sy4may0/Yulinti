using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumInput {
        private readonly MinisteriumInputMotus _miInputMotus;

        private readonly OstiumInputMotusLegibile _osInputMotusLeg;

        public FasciculusOstiorumInput(FasciculusConfigurationumInput configurationum) {
            if (configurationum == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumInputのConfigurationumInputがnullです。");
            }

            _miInputMotus = new MinisteriumInputMotus(configurationum.Motus);
            _osInputMotusLeg = new OstiumInputMotusLegibile(_miInputMotus);
        }

        public IOstiumInputMotusLegibile MotusLeg => _osInputMotusLeg;
    }
}