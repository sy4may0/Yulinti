using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociMutabile {
        void Activare();
        void Deactivare();
        void Transporto(Vector3 positio);
        void IncipereMigrare(Vector3 positio);
    }
}