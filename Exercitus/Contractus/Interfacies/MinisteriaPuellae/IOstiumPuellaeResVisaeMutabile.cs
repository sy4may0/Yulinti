using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeResVisaeMutabile {
        void Activare();
        void Deactivate();
        void ActivareCapitis();
        void ActivarePectoris();
        void ActivareNatium();
        void ActivareNudusAnterior();
        void ActivareNudusPosterior();
        void DeactivateCapitis();
        void DeactivatePectoris();
        void DeactivateNatium();
        void DeactivateNudusAnterior();
        void DeactivateNudusPosterior();
    }
}
