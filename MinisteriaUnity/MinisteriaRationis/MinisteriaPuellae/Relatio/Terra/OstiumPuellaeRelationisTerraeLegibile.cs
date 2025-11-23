using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeRelationisTerraeLegibile : IOstiumPuellaeRelationisTerraeLegibile {
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;
        public OstiumPuellaeRelationisTerraeLegibile(MinisteriumPuellaeRelationisTerrae miPuellaeRelationisTerrae) {
            if (miPuellaeRelationisTerrae == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRelationisTerraeのインスタンスがnullです。");
            }
            _miPuellaeRelationisTerrae = miPuellaeRelationisTerrae;
        }

        public float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        ) { 
            return _miPuellaeRelationisTerrae.AltitudoTerraeDextra(
            rayCastAltitudo, rayCastDistantia
            );
        }
        public float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        ) {
            return _miPuellaeRelationisTerrae.AltitudoTerraeSinistra(
                rayCastAltitudo, rayCastDistantia
            );
        }
    }
}
