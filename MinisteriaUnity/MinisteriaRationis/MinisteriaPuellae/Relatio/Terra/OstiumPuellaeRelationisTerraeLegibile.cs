using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeRelationisTerraeLegibile : IOstiumPuellaeRelationisTerraeLegibile {
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;
        public OstiumPuellaeRelationisTerraeLegibile(MinisteriumPuellaeRelationisTerrae miPuellaeRelationisTerrae) {
            if (miPuellaeRelationisTerrae == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRelationisTerraeのインスタンスがnullです。");
            }
            _miPuellaeRelationisTerrae = miPuellaeRelationisTerrae;
        }

        public float AltitudoTerrae(
            float rayCastAltitudo, float rayCastDistantia, LayerID rayCastStratum
        ) { 
            return _miPuellaeRelationisTerrae.AltitudoTerrae(
            rayCastAltitudo, rayCastDistantia, 
            InterpresStratum.ToStratum(rayCastStratum)
            );
        }
    }
}