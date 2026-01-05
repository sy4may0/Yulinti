using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeAnimationesMutabile {
        void Postulare(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem);
        void Cogere(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem);
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
        void Purgere();
    }
}


