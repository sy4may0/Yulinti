using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeResVisaeMutabile {
        void Activare();
        void Deactivate();
        void ActivareCapitis();
        void ActivarePectoris();
        void ActivareNatium();
        void DeactivateCapitis();
        void DeactivatePectoris();
        void DeactivateNatium();
    }
}
