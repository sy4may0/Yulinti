using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisMutabile {
        void Oriri(Vector3 positio, Quaternion rotatio);
        void Evanescere();
        IOstiumCivisLociMutabile Loci { get; }
        IOstiumCivisAnimationesMutabile Animationes { get; }
    }
}