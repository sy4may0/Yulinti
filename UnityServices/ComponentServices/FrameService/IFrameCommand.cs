namespace Yulinti.UnityServices.ComponentServices {
    public interface IFrameCommand {
        void Tick(float deltaTime);
        void FixedTick(float fixedDeltaTime);
    }
}