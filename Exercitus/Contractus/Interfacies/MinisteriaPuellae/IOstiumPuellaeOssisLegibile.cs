using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeOssisLegibile {
        System.Numerics.Vector3 LegoPositionem(IDPuellaeOssis idOssis);
        System.Numerics.Quaternion LegoRotationem(IDPuellaeOssis idOssis);
        System.Numerics.Vector3 LegoScalam(IDPuellaeOssis idOssis);
    }
}


