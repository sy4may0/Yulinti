using System;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeAnimationesMutabile {
        void PostulareFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false);
        void CogereFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false);
        void PostulareCorporisToti(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false);
        void CogereCorporisToti(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false);
        void CogereDesinentiamFundamenti();
        void CogereDesinentiamCorporisToti();
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
    }
}