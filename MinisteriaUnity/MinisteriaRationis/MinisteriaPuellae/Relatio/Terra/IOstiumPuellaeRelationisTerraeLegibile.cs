using Yulinti.ContractusMinisterii.Terrae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerrae(
            float rayCastAltitudo, float rayCastDistantia, IDStrati rayCastStratum
        );
    }
}