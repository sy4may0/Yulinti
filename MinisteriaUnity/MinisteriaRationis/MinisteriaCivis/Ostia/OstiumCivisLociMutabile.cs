using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociMutabile : IOstiumCivisLociMutabile {
        private readonly MinisteriumCivisLoci _miCivisLoci;
        public OstiumCivisLociMutabile(MinisteriumCivisLoci miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }

        private bool VerificareID(int id) {
            if (id < 0 || id >= _miCivisLoci.Longitudo) return false;
            return true;
        }

        public int[] IDs => _miCivisLoci.IDs;
        public int Longitudo => _miCivisLoci.Longitudo;
        public bool EstActivum(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstActivum(id);
        }
        public void ActivareMotus(int id) {
            if (!VerificareID(id)) return;
            _miCivisLoci.ActivareMotus(id);
        }
        public bool ActivareNavMesh(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.ActivareNavMesh(id);
        }
        public bool Transporto(int id, Vector3 positio, Quaternion rotatio) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.Transporto(id, 
                InterpressNumericus.ToUnity(positio),
                InterpressNumericus.ToUnity(rotatio)
            );
        }
        public void InitareMigrare(int id) {
            if (!VerificareID(id)) return;
            _miCivisLoci.InitareMigrare(id);
        }
        public void IncipereMigrare(int id, Vector3 positio) {
            if (!VerificareID(id)) return;
            _miCivisLoci.IncipereMigrare(id, InterpressNumericus.ToUnity(positio));
        }
        public void PonoVelocitatem(int id, float velocitatem) {
            if (!VerificareID(id)) return;
            _miCivisLoci.PonoVelocitatem(id, velocitatem);
        }
        public void PonoAccelerationem(int id, float accelerationem) {
            if (!VerificareID(id)) return;
            _miCivisLoci.PonoAccelerationem(id, accelerationem);
        }
        public void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg) {
            if (!VerificareID(id)) return;
            _miCivisLoci.PonoVelocitatemRotationis(id, velocitatemRotationisDeg);
        }
        public void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis) {
            if (!VerificareID(id)) return;
            _miCivisLoci.PonoDistantiaDeaccelerationis(id, distantiaDeaccelerationis);
        }
        public void Moto(int id, float velocitasHorizontalisDesiderata, float tempusLevigatumHorizontalis, float rotatioYDesiderata, float tempusLevigatumRotatioY, float intervallum) {
            if (!VerificareID(id)) return;
            _miCivisLoci.Moto(id, velocitasHorizontalisDesiderata, tempusLevigatumHorizontalis, rotatioYDesiderata, tempusLevigatumRotatioY, intervallum);
        }
    }
}
