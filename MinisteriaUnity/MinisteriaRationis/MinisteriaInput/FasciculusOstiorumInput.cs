using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumInput {
        private readonly MinisteriumInputMotus _miInputMotus;

        private readonly OstiumInputMotusLegibile _osInputMotusLeg;

        public FasciculusOstiorumInput(InputConfig inputConfig) {
            if (inputConfig == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumInputのInputConfigがnullです。");
            }

            _miInputMotus = new MinisteriumInputMotus(inputConfig.MoveInputConfig);
            _osInputMotusLeg = new OstiumInputMotusLegibile(_miInputMotus);
        }

        public IOstiumInputMotusLegibile MotusLeg => _osInputMotusLeg;
    }
}