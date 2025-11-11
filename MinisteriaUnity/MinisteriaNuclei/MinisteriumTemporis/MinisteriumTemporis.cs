using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.MinisteriaUnity.MinisteriaNuclei {
    public sealed class MinisteriumTemporis : IServiceTickable, IServiceFixedTickable {
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }

        public MinisteriumTemporis() {
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