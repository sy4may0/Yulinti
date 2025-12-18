using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisMutabile {
        void Creare();
        void CreareSync();
        void Destuere();
        void Incarnare();
        void Spirituare();
        IOstiumCivisLociMutabile Loci { get; }
        IOstiumCivisAnimationesMutabile Animationes { get; }
    }
}