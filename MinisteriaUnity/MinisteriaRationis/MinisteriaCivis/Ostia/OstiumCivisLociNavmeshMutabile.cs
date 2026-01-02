using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociNavmeshMutabile : IOstiumCivisLociNavmeshMutabile {
        private readonly MinisteriumCivisLociNavmesh _miCivisLoci;

        public OstiumCivisLociNavmeshMutabile(MinisteriumCivisLociNavmesh miCivisLoci) {
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
        public void Transporto(int id, Vector3 positio, Quaternion rotatio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.Transporto(
                id, InterpressNumericus.ToUnity(positio), InterpressNumericus.ToUnity(rotatio)
            );
        }
        public void InitareMigrare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.InitareMigrare(id);
        }
        public void IncipereMigrare(int id, Vector3 positio) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.IncipereMigrare(id, InterpressNumericus.ToUnity(positio));
        }
        public void PonoVelocitatem(int id, float velocitatem) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoVelocitatem(id, velocitatem);
        }
        public void PonoAccelerationem(int id, float accelerationem) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoAccelerationem(id, accelerationem);
        }
        public void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoVelocitatemRotationis(id, velocitatemRotationisDeg);
        }
        public void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.PonoDistantiaDeaccelerationis(id, distantiaDeaccelerationis);
        }
        public void TerminareMigrare(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return;
            _miCivisLoci.TerminareMigrare(id);
        }
    }
}
