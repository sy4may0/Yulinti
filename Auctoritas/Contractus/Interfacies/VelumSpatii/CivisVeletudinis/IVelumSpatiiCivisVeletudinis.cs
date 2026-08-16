using System.Numerics;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumSpatiiCivisVeletudinis : IVelumSpatii {
        void Initiare(int longitudo);
        void Liberare();
        void IncarnareUnus(int idCivis);
        void SpirituareUnus(int idCivis);
        void PonoRotationem(int idCivis, Quaternion rotationem);
        void PonoIntentionem(int idCivis, float intentio);
        void PonoSuspectum(int idCivis, float suspecta);
        void PonoTextus(int idCivis, string textus);
    }
}