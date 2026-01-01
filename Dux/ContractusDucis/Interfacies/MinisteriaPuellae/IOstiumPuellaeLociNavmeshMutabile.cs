using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeLociNavmeshMutabile {
        void Activare();
        void Deactivare();
        void Transporto(Vector3 positio, Quaternion rotatio);
        void IncipereMigrare(Vector3 positio);
        void PonoVelocitatem(float velocitatem);
        void PonoAccelerationem(float accelerationem);
        void PonoVelocitatemRotationis(int velocitatemRotationisDeg);
        void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis);
        void TerminareMigrare();
    }
}
