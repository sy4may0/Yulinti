using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.MinisteriaUnity.MinisteriaNuclei {
    public sealed class OstiumTemporisMutabile : IOstiumTemporisMutabile {
        private readonly MinisteriumTemporis _miTemporis;

        public OstiumTemporisMutabile(MinisteriumTemporis miTemporis) {
            if (miTemporis == null) {
                ModeratorErrorum.Fatal("MinisteriumTemporisのインスタンスがnullです。");
            }
            _miTemporis = miTemporis;
        }

        public void Tick(float deltaTime) {
            _miTemporis.Tick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime) {
            _miTemporis.FixedTick(fixedDeltaTime);
        }
    }
}