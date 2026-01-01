using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociLegibile : IOstiumCivisLociLegibile {
        private readonly MinisteriumCivisLoci _miCivisLoci;
        public OstiumCivisLociLegibile(MinisteriumCivisLoci miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }
        public int[] IDs => _miCivisLoci.IDs;
        public int Longitudo => _miCivisLoci.Longitudo;

        public bool EstActivum(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return _miCivisLoci.EstActivum(id);
        }
        public float VelHorizontalisActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.VelocitasHorizontalisActualis(id);
        }
        public float VelVerticalisActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.VelocitasVerticalisActualis(id);
        }
        public float RotatioYActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.RotatioYActualis(id);
        }
        public Vector3 Positio(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return new Vector3(0,0,0);
            return InterpressNumericus.ToNumerics(_miCivisLoci.Positio(id));
        }
        public Quaternion Rotatio(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return new Quaternion(0,0,0,1);
            return InterpressNumericus.ToNumerics(_miCivisLoci.Rotatio(id));
        }
    }
}