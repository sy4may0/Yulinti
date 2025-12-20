using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        void Activare(int id);
        void Deactivare(int id);
        void Transporto(int id, Vector3 positio);
        void IncipereMigrare(int id, Vector3 positio);
        void TerminareMigrare(int id);
    }
}