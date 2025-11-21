using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumInputMotusLegibile : IOstiumInputMotusLegibile {
        private readonly MinisteriumInputMotus _miInputMotus;

        public OstiumInputMotusLegibile(MinisteriumInputMotus miInputMotus) {
            if (miInputMotus == null) {
                ModeratorErrorum.Fatal("MinisteriumInputMotusのインスタンスがnullです。");
            }
            _miInputMotus = miInputMotus;
        }

        public System.Numerics.Vector2 LegoMotus => InterpressNumericus.ToNumerics(_miInputMotus.LegoMotus);
        public bool LegoCursus => _miInputMotus.LegoCursus;
        public bool LegoIncumbo => _miInputMotus.LegoIncumbo;
    }
}
