using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumCivisAnimationesMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstExhibens(int id, IDCivisAnimationisStratum stratum);
        bool EstDesinens(int id, IDCivisAnimationisStratum stratum);
        bool EstExhibensIterans(int id, IDCivisAnimationisStratum stratum);
        void Exhibere(int id, IDCivisAnimationisStratum stratum, IDCivisAnimationis idAnimationis);
        void Desinere(int id, IDCivisAnimationisStratum stratum);
        void InjicereVelocitatem(int id, float vel);
        void Purgere(int id, IDCivisAnimationisStratum stratum);
    }
}
