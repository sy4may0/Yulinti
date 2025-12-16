using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisAnimationesMutabile : IOstiumCivisAnimationesMutabile {
        private readonly MinisteriumCivisAnimationes _ministeriumAnimationes;

        public OstiumCivisAnimationesMutabile(MinisteriumCivisAnimationes ministeriumAnimationes) {
            _ministeriumAnimationes = ministeriumAnimationes;
        }

        public void Postulare(IDCivisAnimationisContinuata idContinuata, Action adInitium, Action adFinem) {
            _ministeriumAnimationes.Postulare(idContinuata, adInitium, adFinem);
        }
        public void Cogere(IDCivisAnimationisContinuata idContinuata, Action adInitium, Action adFinem) {
            _ministeriumAnimationes.Cogere(idContinuata, adInitium, adFinem);
        }
        public void TemporareLuditores() {
            _ministeriumAnimationes.TemporareLuditores();
        }
        public void InjicereVelocitatem(float vel) {
            _ministeriumAnimationes.InjicereVelocitatem(vel);
        }
    }
}