using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumPuellaeAnimationisMutabile {
        bool EstExhibens(IDPuellaeAnimationisStratum stratum);
        bool EstDesinens(IDPuellaeAnimationisStratum stratum);
        bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum);
        void Exhibere(IDPuellaeAnimationisStratum stratum, IDPuellaeAnimationis id);
        void Desinere(IDPuellaeAnimationisStratum stratum);
        void InjicereVelocitatem(float vel);
        void Purgere(IDPuellaeAnimationisStratum stratum);
    }
}