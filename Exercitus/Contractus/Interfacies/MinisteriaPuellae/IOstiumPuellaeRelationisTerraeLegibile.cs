using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        );
        float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        );
    }
}


