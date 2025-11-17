using System;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeAnimationesMutabile {
        void PostulareFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false);
        void CogereFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false);
        void PostulareCorporis(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false);
        void CogereCorporis(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false);
        void CogereDesinentiamFundamenti();
        void CogereDesinentiamCorporis();
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
    }
}