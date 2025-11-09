using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.TranslateUtils;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class CameraRW : ICameraCommand, ICameraQuery {
        private readonly CameraService _cameraService;

        public CameraRW(CameraService cameraService) {
            if (cameraService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(CameraService)のCameraServiceがnullです。");
            }
            _cameraService = cameraService;
        }

        public System.Numerics.Quaternion YawRotation => NumericsTranslate.ToNumerics(_cameraService.YawRotation);
        public System.Numerics.Vector3 RightXZ => NumericsTranslate.ToNumerics(_cameraService.RightXZ);
        public System.Numerics.Vector3 ForwardXZ => NumericsTranslate.ToNumerics(_cameraService.ForwardXZ);

        public void SetPosition(System.Numerics.Vector3 position) {
            _cameraService.SetPosition(NumericsTranslate.ToUnity(position));
        }
        public void SetRotation(System.Numerics.Quaternion rotation) {
            _cameraService.SetRotation(NumericsTranslate.ToUnity(rotation));
        }
    }
}
