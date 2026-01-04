using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisVisaeLegibile {
        bool EstVisa(int idCivis, Vector3 positio);
        bool ConareLegoPositioCapitis(int idCivis, out Vector3 positio);
        bool ConareLegoDirectioCapitis(int idCivis, out Vector3 directio);
    }
}