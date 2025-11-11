using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.InstrumentaMinisterii;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class CameraRW : ICameraCommand, ICameraQuery {
        private readonly CameraService _cameraService;

        public CameraRW(CameraService cameraService) {
            if (cameraService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(CameraService)のCameraServiceがnullです。");
            }
            _cameraService = cameraService;
        }

        public System.Numerics.Quaternion YawRotation => InterpressNumericus.ToNumerics(_cameraService.YawRotation);
        public System.Numerics.Vector3 RightXZ => InterpressNumericus.ToNumerics(_cameraService.RightXZ);
        public System.Numerics.Vector3 ForwardXZ => InterpressNumericus.ToNumerics(_cameraService.ForwardXZ);

        public void SetPosition(System.Numerics.Vector3 position) {
            _cameraService.SetPosition(InterpressNumericus.ToUnity(position));
        }
        public void SetRotation(System.Numerics.Quaternion rotation) {
            _cameraService.SetRotation(InterpressNumericus.ToUnity(rotation));
        }
    }
}
