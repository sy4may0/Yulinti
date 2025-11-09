namespace Yulinti.UnityServices.ComponentServices {
    public interface ICameraQuery {
        System.Numerics.Quaternion YawRotation { get; }
        System.Numerics.Vector3 RightXZ { get; }
        System.Numerics.Vector3 ForwardXZ { get; }
    }
}