using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisAnimationesMutabile : IOstiumCivisAnimationesMutabile {
        private readonly MinisteriumCivisAnimationes _miCivisAnimationes;

        public OstiumCivisAnimationesMutabile(MinisteriumCivisAnimationes miCivisAnimationes) {
            _miCivisAnimationes = miCivisAnimationes;
        }

        public int[] IDs => _miCivisAnimationes.IDs;
        public int Longitudo => _miCivisAnimationes.Longitudo;
        public bool EstActivum(int id) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return false;
            return _miCivisAnimationes.EstActivum(id);
        }
        public void Postulare(int id, IDCivisAnimationisContinuata idAnimationis, Action adInitium, Action adFinem) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.Postulare(id, idAnimationis, adInitium, adFinem);
        }
        public void Cogere(int id, IDCivisAnimationisContinuata idAnimationis, Action adInitium, Action adFinem) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.Cogere(id, idAnimationis, adInitium, adFinem);
        }
        public void TemporareLuditores(int id) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.TemporareLuditores(id);
        }
        public void InjicereVelocitatem(int id, float vel) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.InjicereVelocitatem(id, vel);
        }
    }
}