using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.ContractusMinisterii.Terrae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeRelationisTerraeLegibile : IOstiumPuellaeRelationisTerraeLegibile {
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;
        public OstiumPuellaeRelationisTerraeLegibile(MinisteriumPuellaeRelationisTerrae miPuellaeRelationisTerrae) {
            if (miPuellaeRelationisTerrae == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRelationisTerraeのインスタンスがnullです。");
            }
            _miPuellaeRelationisTerrae = miPuellaeRelationisTerrae;
        }

        public float AltitudoTerrae(
            float rayCastAltitudo, float rayCastDistantia, IDStrati rayCastStratum
        ) { 
            return _miPuellaeRelationisTerrae.AltitudoTerrae(
            rayCastAltitudo, rayCastDistantia, 
            InterpresStratum.ToStratum(rayCastStratum)
            );
        }
    }
}
