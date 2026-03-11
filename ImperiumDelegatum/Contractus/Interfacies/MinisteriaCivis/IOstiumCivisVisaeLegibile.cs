using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumCivisVisaeLegibile {
        bool EstVisa(int idCivis, Vector3 positio);
        bool ConareLegoPositioCapitis(int idCivis, out Vector3 positio);
        bool ConareLegoDirectioCapitis(int idCivis, out Vector3 directio);
    }
}