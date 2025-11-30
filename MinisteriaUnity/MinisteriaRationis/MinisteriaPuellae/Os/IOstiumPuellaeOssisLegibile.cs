using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeOssisLegibile {
        System.Numerics.Vector3 LegoPositionem(IDPuellaeOssis idOssis);
        System.Numerics.Quaternion LegoRotationem(IDPuellaeOssis idOssis);
        System.Numerics.Vector3 LegoScalam(IDPuellaeOssis idOssis);
    }
}


