namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaCharacterControllerCommand {
        void ForceSetPosition(System.Numerics.Vector3 position);
        void ForceSetRotation(System.Numerics.Quaternion rotation);
        void SmoothMoveHorizontalBySpeed(float targetSpeed, float smoothTime, float deltaTime);
        void SmoothMoveVerticalBySpeed(float targetSpeed, float smoothTime, float deltaTime);
        void SmoothRotateByYaw(float targetYaw, float smoothTime, float deltaTime);
        void ApplyMove(float deltaTime);
    }
}