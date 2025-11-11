using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class CameraServiceRoot {
        private readonly CameraService _mainCameraService;

        private readonly CameraRO _mainCameraRO;
        private readonly CameraRW _mainCameraRW;

        public CameraServiceRoot(CameraRootConfig cameraRootConfig) {
            if (cameraRootConfig == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(CameraServiceRoot)のCameraRootConfigがnullです。");
            }

            _mainCameraService = new CameraService(cameraRootConfig.MainCameraConfig);

            _mainCameraRO = new CameraRO(_mainCameraService);
            _mainCameraRW = new CameraRW(_mainCameraService);
        }

        public CameraRO MainCameraRO => _mainCameraRO;
        public CameraRW MainCameraRW => _mainCameraRW;
    }
}