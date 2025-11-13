using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;

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

        public FasciculusOstiorumCamera(CameraRootConfig cameraRootConfig) {
            if (cameraRootConfig == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumCameraのCameraRootConfigがnullです。");
            }

            _miCameraPri = new MinisteriumCamera(cameraRootConfig.MainCameraConfig);
            _osCameraPriLeg = new OstiumCameraLegibile(_miCameraPri);
            _osCameraPriMut = new OstiumCameraMutabile(_miCameraPri);
        }

        public OstiumCameraLegibile PrincepsLeg => _osCameraPriLeg;
        public OstiumCameraMutabile PrincepsMut => _osCameraPriMut;
    }
}