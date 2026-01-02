using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociNavmeshMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        void Activare(int id);
        void Deactivare(int id);
        void InitareMigrare(int id);
        void Transporto(int id, Vector3 positio, Quaternion rotatio);
        void IncipereMigrare(int id, Vector3 positio);
        void PonoVelocitatem(int id, float velocitatem);
        void PonoAccelerationem(int id, float accelerationem);
        void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg);
        void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis);
        void TerminareMigrare(int id);
    }
}
