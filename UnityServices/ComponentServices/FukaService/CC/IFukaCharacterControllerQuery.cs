namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaCharacterControllerQuery {
        float CurrentSpeedHorizontal { get; }
        float CurrentSpeedVertical { get; }
        float CurrentYaw { get; }
        System.Numerics.Vector3 CurrentPosition { get; }
        System.Numerics.Quaternion CurrentRotation { get; }
    }
}