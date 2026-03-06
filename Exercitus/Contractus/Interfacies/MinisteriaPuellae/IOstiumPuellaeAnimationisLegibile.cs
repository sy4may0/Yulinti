using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeAnimationisLegibile {
        bool EstExhibens(IDPuellaeAnimationisStratum stratum);
        bool EstDesinens(IDPuellaeAnimationisStratum stratum);
        bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum);
    }
}