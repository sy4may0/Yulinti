using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisAnimationesMutabile {
        void Postulare(IDCivisAnimationisContinuata idAnimationis, Action adInitium, Action adFinem);
        void Cogere(IDCivisAnimationisContinuata idAnimationis, Action adInitium, Action adFinem);
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
    }
}