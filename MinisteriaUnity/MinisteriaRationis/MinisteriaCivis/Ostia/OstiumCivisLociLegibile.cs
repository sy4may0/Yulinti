using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociLegibile : IOstiumCivisLociLegibile {
        private readonly MinisteriumCivisLoci _miCivisLoci;
        public OstiumCivisLociLegibile(MinisteriumCivisLoci miCivisLoci) {
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
        public bool EstErrans(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstErrans(id);
        }
        public bool EstActivumMotus(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstActivumMotus(id);
        }
        public bool EstActivumNavMesh(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstActivumNavMesh(id);
        }
        public bool EstAdPerveni(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstAdPerveni(id);
        }
        public bool EstMigrare(int id) {
            if (!VerificareID(id)) return false;
            return _miCivisLoci.EstMigrare(id);
        }
        public float VelocitasHorizontalisActualis(int id) {
            if (!VerificareID(id)) return 0f;
            return _miCivisLoci.VelocitasHorizontalisActualis(id);
        }
        public float RotatioYActualis(int id) {
            if (!VerificareID(id)) return 0f;
            return _miCivisLoci.RotatioYActualis(id);
        }
        public Vector3 Positio(int id) {
            if (!VerificareID(id)) return new Vector3(0f, 0f, 0f);
            return InterpressNumericus.ToNumerics(_miCivisLoci.Positio(id));
        }
        public Quaternion Rotatio(int id) {
            if (!VerificareID(id)) return new Quaternion(0f, 0f, 0f, 1f);
            return InterpressNumericus.ToNumerics(_miCivisLoci.Rotatio(id));
        }
    }
}
