using UnityEngine;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FrameService : IServiceTickable, IServiceFixedTickable {
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }

        public FrameService() {
            DeltaTime = 0f;
            FixedDeltaTime = 0f;
        }

        public void Tick(float deltaTime) {
            DeltaTime = deltaTime;
        }

        public void FixedTick(float fixedDeltaTime) {
            FixedDeltaTime = fixedDeltaTime;
        }
    }
}