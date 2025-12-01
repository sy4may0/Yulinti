using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeOssisMutabile {
        void PonoPositionem(IDPuellaeOssis idOssis, System.Numerics.Vector3 positio);
        void PonoRotationem(IDPuellaeOssis idOssis, System.Numerics.Quaternion rotatio);
        void PonoScalam(IDPuellaeOssis idOssis, System.Numerics.Vector3 scala);
    }
}


