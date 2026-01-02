using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociNavmeshLegibile : IOstiumCivisLociNavmeshLegibile {
        private readonly MinisteriumCivisLociNavmesh _miCivisLoci;

        public OstiumCivisLociNavmeshLegibile(MinisteriumCivisLociNavmesh miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }

        public int[] IDs => _miCivisLoci.IDs;
        public int Longitudo => _miCivisLoci.Longitudo;
        public bool EstActivum(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return _miCivisLoci.EstActivum(id);
        }
        public bool EstAdPerveni(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return _miCivisLoci.EstAdPerveni(id);
        }
        public bool EstMigrare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return _miCivisLoci.EstMigrare(id);
        }
        public float VelocitasHorizontalisActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.VelocitasHorizontalisActualis(id);
        }
        public float VelocitasVerticalisActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.VelocitasVerticalisActualis(id);
        }
        public float RotatioYActualis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.RotatioYActualis(id);
        }
        public float LegoVelocitatem(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.LegoVelocitatem(id);
        }
        public float LegoAccelerationem(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.LegoAccelerationem(id);
        }
        public float LegoDistantiaDeaccelerationis(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0f;
            return _miCivisLoci.LegoDistantiaDeaccelerationis(id);
        }
        public int LegoVelocitatemRotationisDeg(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return 0;
            return _miCivisLoci.LegoVelocitatemRotationisDeg(id);
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
