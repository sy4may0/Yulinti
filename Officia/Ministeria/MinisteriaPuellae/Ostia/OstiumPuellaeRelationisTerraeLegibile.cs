using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeRelationisTerraeLegibile : IOstiumPuellaeRelationisTerraeLegibile {
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;
        public OstiumPuellaeRelationisTerraeLegibile(MinisteriumPuellaeRelationisTerrae miPuellaeRelationisTerrae) {
            if (miPuellaeRelationisTerrae == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeRelationisTerraeLegibile_OSTIUMPUELLAERELATIONISTERRAELEGIBILE_INSTANCE_NULL);
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


