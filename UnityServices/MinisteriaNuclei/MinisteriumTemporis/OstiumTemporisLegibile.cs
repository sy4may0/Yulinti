using Yulinti.MinisteriaNuclei.ModeratorErrorum;

namespace Yulinti.MinisteriaNuclei.MinisteriumTemporis {
    public sealed class OstiumTemporisLegibile : IOstiumTemporisLegibile {
        private readonly MinisteriumTemporis _miTemporis;

        public OstiumTemporisLegibile(MinisteriumTemporis miTemporis) {
            if (miTemporis == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FrameService)のインスタンスがnullです。");
            }
            _miTemporis = miTemporis;
        }

        public float DeltaTime => _miTemporis.DeltaTime;
        public float FixedDeltaTime => _miTemporis.FixedDeltaTime;
    }
}