using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeRelationisTerraeLegibile : IOstiumPuellaeRelationisTerraeLegibile {
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;
        public OstiumPuellaeRelationisTerraeLegibile(MinisteriumPuellaeRelationisTerrae miPuellaeRelationisTerrae) {
            if (miPuellaeRelationisTerrae == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAERELATIONISTERRAELEGIBILE_INSTANCE_NULL);
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
