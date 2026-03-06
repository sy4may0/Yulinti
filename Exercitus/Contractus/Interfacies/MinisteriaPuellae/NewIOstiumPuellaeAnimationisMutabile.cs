using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface NewIOstiumPuellaeAnimationisMutabile {
        bool EstExhibens(IDPuellaeAnimationisStratum stratum);
        bool EstDesinens(IDPuellaeAnimationisStratum stratum);
        bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum);
        void Exhibere(IDPuellaeAnimationisStratum stratum, NewIDPuellaeAnimationis id);
        void Desinere(IDPuellaeAnimationisStratum stratum);
        void InjicereVelocitatem(float vel);
        void Purgere(IDPuellaeAnimationisStratum stratum);
    }
}