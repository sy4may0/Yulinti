using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.TranslateUtils;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaCharacterControllerRO : IFukaCharacterControllerQuery {
        private readonly FukaCharacterControllerService _fukaCharacterControllerService;
        public FukaCharacterControllerRO(FukaCharacterControllerService fukaCharacterControllerService) {
            if (fukaCharacterControllerService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaCharacterControllerRO)のFukaCharacterControllerServiceがnullです。");
            }
            _fukaCharacterControllerService = fukaCharacterControllerService;
        }
        public float CurrentSpeedHorizontal => _fukaCharacterControllerService.CurrentSpeedHorizontal;
        public float CurrentSpeedVertical => _fukaCharacterControllerService.CurrentSpeedVertical;
        public float CurrentYaw => _fukaCharacterControllerService.CurrentYaw;
        public System.Numerics.Vector3 CurrentPosition => NumericsTranslate.ToNumerics(_fukaCharacterControllerService.CurrentPosition);
        public System.Numerics.Quaternion CurrentRotation => NumericsTranslate.ToNumerics(_fukaCharacterControllerService.CurrentRotation);
    }
}