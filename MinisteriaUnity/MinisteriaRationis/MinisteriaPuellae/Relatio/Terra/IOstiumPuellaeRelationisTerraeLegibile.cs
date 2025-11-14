using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerrae(
            float rayCastAltitudo, float rayCastDistantia, LayerID rayCastStratum
        );
    }
}