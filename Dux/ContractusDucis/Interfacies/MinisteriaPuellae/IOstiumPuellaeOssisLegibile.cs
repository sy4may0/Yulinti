using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeOssisLegibile {
        System.Numerics.Vector3 LegoPositionem(IDPuellaeOssis idOssis);
        System.Numerics.Quaternion LegoRotationem(IDPuellaeOssis idOssis);
        System.Numerics.Vector3 LegoScalam(IDPuellaeOssis idOssis);
    }
}


