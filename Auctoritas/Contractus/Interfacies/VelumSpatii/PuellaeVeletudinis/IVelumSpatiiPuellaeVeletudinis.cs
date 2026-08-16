using System.Numerics;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumSpatiiPuellaeVeletudinis : IVelumSpatii {
        void PonoRotationem(Quaternion rotationem);

        void PonoVigorem(float ratioVigoris);
        void PonoPatientiam(float ratioPatientiae);

        void PonoTextus(string textus);
    }
}
