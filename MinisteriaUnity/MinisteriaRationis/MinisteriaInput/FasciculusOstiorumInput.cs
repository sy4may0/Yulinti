using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumInput {
        private readonly MinisteriumInputMotus _miInputMotus;

        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;

        public FasciculusOstiorumInput(FasciculusConfigurationumInput configurationum) {
            if (configurationum == null) {
                Errorum.Fatal(IDErrorum.FASCICULUSOSTIORUMINPUT_CONFIG_NULL);
            }

            _miInputMotus = new MinisteriumInputMotus(configurationum.Motus);
            _osInputMotusLeg = new OstiumInputMotusLegibile(_miInputMotus);
        }

        public IOstiumInputMotusLegibile MotusLeg => _osInputMotusLeg;
    }
}
