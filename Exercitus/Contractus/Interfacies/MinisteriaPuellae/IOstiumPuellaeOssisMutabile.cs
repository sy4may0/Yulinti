using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeOssisMutabile {
        void PonoPositionem(IDPuellaeOssis idOssis, System.Numerics.Vector3 positio);
        void PonoRotationem(IDPuellaeOssis idOssis, System.Numerics.Quaternion rotatio);
        void PonoScalam(IDPuellaeOssis idOssis, System.Numerics.Vector3 scala);
    }
}


