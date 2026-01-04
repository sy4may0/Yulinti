using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisVisaeLegibile : IOstiumCivisVisaeLegibile {
        private readonly MinisteriumCivisVisae _miCivisVisae;

        public OstiumCivisVisaeLegibile(MinisteriumCivisVisae miCivisVisae) {
            _miCivisVisae = miCivisVisae;
        }

        public bool EstVisa(int idCivis, Vector3 positio) {
            return _miCivisVisae.EstVisa(idCivis, InterpressNumericus.ToUnity(positio));
        }

        public bool ConareLegoPositioCapitis(int idCivis, out Vector3 positio) {
            if (!_miCivisVisae.ConareLegoPositioCapitis(idCivis, out UnityEngine.Vector3 positioP)) {
                positio = new Vector3(0f, 0f, 0f);
                return false;
            }
            positio = InterpressNumericus.ToNumerics(positioP);
            return true;
        }

        public bool ConareLegoDirectioCapitis(int idCivis, out Vector3 directio) {
            if (!_miCivisVisae.ConareLegoDirectioCapitis(idCivis, out UnityEngine.Vector3 directioP)) {
                directio = new Vector3(0f, 0f, 0f);
                return false;
            }
            directio = InterpressNumericus.ToNumerics(directioP);
            return true;
        }
    }
}