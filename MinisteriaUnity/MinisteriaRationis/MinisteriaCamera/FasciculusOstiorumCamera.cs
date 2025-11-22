using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

// ラテン語note
// Main => Camera Princeps
// Secondary => Camera Secundaria
// Third => Camera Tertia
// Forth => Camera Quarta
// 追従 => Camera Subordinata
// 補助 => Camera Auxiliaria

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumCamera {
        private readonly MinisteriumCamera _miCameraPri;

        private readonly IOstiumCameraLegibile _osCameraPriLeg;
        private readonly IOstiumCameraMutabile _osCameraPriMut;

        public FasciculusOstiorumCamera(FasciculusConfigurationumCamera configurationes) {
            if (configurationes == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumCameraのConfigurationesがnullです。");
            }

            _miCameraPri = new MinisteriumCamera(configurationes.ConfiguratioCameraPrincips);
            _osCameraPriLeg = new OstiumCameraLegibile(_miCameraPri);
            _osCameraPriMut = new OstiumCameraMutabile(_miCameraPri);
        }

        public IOstiumCameraLegibile PrincepsLeg => _osCameraPriLeg;
        public IOstiumCameraMutabile PrincepsMut => _osCameraPriMut;
    }
}