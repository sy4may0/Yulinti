using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        );
        float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        );
    }
}


