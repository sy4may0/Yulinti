using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.Nucleus.InstrumentaMinisterii;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaCharacterControllerRW : IFukaCharacterControllerCommand, IFukaCharacterControllerQuery {
        private readonly FukaCharacterControllerService _fukaCharacterControllerService;
        public FukaCharacterControllerRW(FukaCharacterControllerService fukaCharacterControllerService) {
            if (fukaCharacterControllerService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaCharacterControllerRW)のFukaCharacterControllerServiceがnullです。");
            }
            _fukaCharacterControllerService = fukaCharacterControllerService;
        }

        public float CurrentSpeedHorizontal => _fukaCharacterControllerService.CurrentSpeedHorizontal;
        public float CurrentSpeedVertical => _fukaCharacterControllerService.CurrentSpeedVertical;
        public float CurrentYaw => _fukaCharacterControllerService.CurrentYaw;
        public System.Numerics.Vector3 CurrentPosition => InterpressNumericus.ToNumerics(_fukaCharacterControllerService.CurrentPosition);
        public System.Numerics.Quaternion CurrentRotation => InterpressNumericus.ToNumerics(_fukaCharacterControllerService.CurrentRotation);

        public void ForceSetPosition(System.Numerics.Vector3 position) {
            _fukaCharacterControllerService.ForceSetPosition(InterpressNumericus.ToUnity(position));
        }
        public void ForceSetRotation(System.Numerics.Quaternion rotation) {
            _fukaCharacterControllerService.ForceSetRotation(InterpressNumericus.ToUnity(rotation));
        }
        public void SmoothMoveHorizontalBySpeed(float targetSpeed, float smoothTime, float deltaTime) {
            _fukaCharacterControllerService.SmoothMoveHorizontalBySpeed(targetSpeed, smoothTime, deltaTime);
        }
        public void SmoothMoveVerticalBySpeed(float targetSpeed, float smoothTime, float deltaTime) {
            _fukaCharacterControllerService.SmoothMoveVerticalBySpeed(targetSpeed, smoothTime, deltaTime);
        }
        public void SmoothRotateByYaw(float targetYaw, float smoothTime, float deltaTime) {
            _fukaCharacterControllerService.SmoothRotateByYaw(targetYaw, smoothTime, deltaTime);
        }
        public void ApplyMove(float deltaTime) {
            _fukaCharacterControllerService.ApplyMove(deltaTime);
        }
    }
}