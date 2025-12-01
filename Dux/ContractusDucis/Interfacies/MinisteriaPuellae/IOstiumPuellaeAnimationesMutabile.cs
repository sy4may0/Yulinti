using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeAnimationesMutabile {
        void PostulareFundamenti(IDPuellaeAnimationisFundamenti idFundamenti, Action fInvocanda, bool estObsignatus = false);
        void CogereFundamenti(IDPuellaeAnimationisFundamenti idFundamenti, Action fInvocanda, bool estObsignatus = false);
        void PostulareCorporis(IDPuellaeAnimationisCorporis idCorporis, Action fInvocanda, bool estObsignatus = false);
        void CogereCorporis(IDPuellaeAnimationisCorporis idCorporis, Action fInvocanda, bool estObsignatus = false);
        void CogereDesinentiamFundamenti();
        void CogereDesinentiamCorporis();
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
    }
}


