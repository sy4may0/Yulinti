using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumPuellaeOssisMutabile {
        void PonoPositionem(IDPuellaeOssis idOssis, System.Numerics.Vector3 positio);
        void PonoRotationem(IDPuellaeOssis idOssis, System.Numerics.Quaternion rotatio);
        void PonoScalam(IDPuellaeOssis idOssis, System.Numerics.Vector3 scala);
    }
}


