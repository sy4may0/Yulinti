using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociMutabile : IOstiumCivisLociMutabile {
        private readonly MinisteriumCivisLoci _miCivisLoci;

        public OstiumCivisLociMutabile(MinisteriumCivisLoci miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }

        public int[] IDs => _miCivisLoci.IDs;
        public int Longitudo => _miCivisLoci.Longitudo;
        public bool EstActivum(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return _miCivisLoci.EstActivum(id);
        }
        public void Activare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.Activare(id);
        }
        public void Deactivare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.Deactivare(id);
        }
        public void Transporto(int id, Vector3 positio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.Transporto(id, InterpressNumericus.ToUnity(positio));
        }
        public void IncipereMigrare(int id, Vector3 positio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.IncipereMigrare(id, InterpressNumericus.ToUnity(positio));
        }
        public void TerminareMigrare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.TerminareMigrare(id);
        }
    }
}