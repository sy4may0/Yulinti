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
        public void PonoPositionemCoacte(int id, Vector3 positio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoPositionemCoacte(id, InterpressNumericus.ToUnity(positio));
        }
        public void PonoRotationemCoacte(int id, Quaternion rotatio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoRotationemCoacte(id, InterpressNumericus.ToUnity(rotatio));
        }
        public void Moto(
            int id, 
            float velocitasHorizontalisDesiderata, 
            float tempusLevigatumHorizontalis, 
            float velocitasVerticalisDesiderata, 
            float tempusLevigatumVerticalis, 
            float rotatioYDesiderata, 
            float tempusLevigatumRotatioY, 
            float intervallum
        ) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.Moto(
                id, 
                velocitasHorizontalisDesiderata, 
                tempusLevigatumHorizontalis, 
                velocitasVerticalisDesiderata, 
                tempusLevigatumVerticalis, 
                rotatioYDesiderata, 
                tempusLevigatumRotatioY, 
                intervallum
            );
        }
    }
}