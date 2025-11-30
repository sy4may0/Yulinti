using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

// ラチE��語note
// Main => Camera Princeps
// Secondary => Camera Secundaria
// Third => Camera Tertia
// Forth => Camera Quarta
// 追征E=> Camera Subordinata
// 補助 => Camera Auxiliaria

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumCamera {
        private readonly MinisteriumCamera _miCameraPri;

        private readonly IOstiumCameraLegibile _osCameraPriLeg;
        private readonly IOstiumCameraMutabile _osCameraPriMut;

        public FasciculusOstiorumCamera(IAnchoraCamera anchoraCamera) {
            _miCameraPri = new MinisteriumCamera(anchoraCamera);
            _osCameraPriLeg = new OstiumCameraLegibile(_miCameraPri);
            _osCameraPriMut = new OstiumCameraMutabile(_miCameraPri);
        }

        public IOstiumCameraLegibile PrincepsLeg => _osCameraPriLeg;
        public IOstiumCameraMutabile PrincepsMut => _osCameraPriMut;
    }
}



