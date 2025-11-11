using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.InstrumentaMinisterii;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class CameraRO : ICameraQuery {
        private readonly CameraService _cameraService;

        public CameraRO(CameraService cameraService) {
            if (cameraService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(CameraService)のCameraServiceがnullです。");
            }
            _cameraService = cameraService;
        }

        public System.Numerics.Quaternion YawRotation => InterpressNumericus.ToNumerics(_cameraService.YawRotation);
        public System.Numerics.Vector3 RightXZ => InterpressNumericus.ToNumerics(_cameraService.RightXZ);
        public System.Numerics.Vector3 ForwardXZ => InterpressNumericus.ToNumerics(_cameraService.ForwardXZ);
    }
}
