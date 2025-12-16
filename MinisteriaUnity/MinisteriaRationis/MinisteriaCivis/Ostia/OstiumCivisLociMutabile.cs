using System.Numerics;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociMutabile : IOstiumCivisLociMutabile {
        private readonly MinisteriumCivisLoci _miCivisLoci;

        public OstiumCivisLociMutabile(MinisteriumCivisLoci miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }

        public void Activare() {
            _miCivisLoci.Activare();
        }
        public void Deactivare() {
            _miCivisLoci.Deactivare();
        }
        public void Transporto(Vector3 positio) {
            _miCivisLoci.Transporto(InterpressNumericus.ToUnity(positio));
        }

        public void IncipereMigrare(Vector3 positio) {
            _miCivisLoci.IncipereMigrare(InterpressNumericus.ToUnity(positio));
        }
        public void TerminareMigrare() {
            _miCivisLoci.TerminareMigrare();
        }
    }
}