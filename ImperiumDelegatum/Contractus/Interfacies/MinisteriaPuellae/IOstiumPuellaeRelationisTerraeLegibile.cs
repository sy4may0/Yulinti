using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        );
        float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        );
    }
}


