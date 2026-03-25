using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumCivisAnimationesLegibile {
        bool EstExhibens(int id, IDCivisAnimationisStratum stratum);
        bool EstDesinens(int id, IDCivisAnimationisStratum stratum);
        bool EstExhibensIterans(int id, IDCivisAnimationisStratum stratum);
    }
}