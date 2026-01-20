using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeRelationisTerraeLegibile {
        float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        );
        float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        );
    }
}


