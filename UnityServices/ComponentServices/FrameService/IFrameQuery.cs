namespace Yulinti.UnityServices.ComponentServices {
    public interface IFrameQuery {
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
    }
}