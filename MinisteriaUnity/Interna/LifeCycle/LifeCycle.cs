namespace Yulinti.UnityServices.Internal.LifeCycle {
    public interface IServiceTickable {
        void Tick(float deltaTime);
    }

    public interface IServiceFixedTickable {
        void FixedTick(float fixedDeltaTime);
    }

    public interface IServiceLateTickable {
        void LateTick(float deltaTime);
    }
}