using Yulinti.MinisteriaUnity.MinisteriaNuclei;
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

        private readonly OstiumCameraLegibile _osCameraPriLeg;
        private readonly OstiumCameraMutabile _osCameraPriMut;

        public FasciculusOstiorumCamera(FasciculusConfigurationumCamera configurationes) {
            if (configurationes == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumCameraのConfigurationesがnullです。");
            }

            _miCameraPri = new MinisteriumCamera(configurationes.ConfiguratioCameraPrincips);
            _osCameraPriLeg = new OstiumCameraLegibile(_miCameraPri);
            _osCameraPriMut = new OstiumCameraMutabile(_miCameraPri);
        }

        public OstiumCameraLegibile PrincepsLeg => _osCameraPriLeg;
        public OstiumCameraMutabile PrincepsMut => _osCameraPriMut;
    }
}