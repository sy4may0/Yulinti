using System;
using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeAnimationesMutabile : IOstiumPuellaeAnimationesMutabile {
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        public OstiumPuellaeAnimationesMutabile(MinisteriumPuellaeAnimationes miPuellaeAnimationes) {
            if (miPuellaeAnimationes == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeAnimationesMutabile_OSTIUMPUELLAEANIMATIONESMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeAnimationes = miPuellaeAnimationes;
        }

        public void Postulare(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem) {
            _miPuellaeAnimationes.Postulare(idContinuata, adInitium, adFinem);
        }
        public void Cogere(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem) {
            _miPuellaeAnimationes.Cogere(idContinuata, adInitium, adFinem);
        }

        public void TemporareLuditores() {
            _miPuellaeAnimationes.TemporareLuditores();
        }
        public void InjicereVelocitatem(float vel) {
            _miPuellaeAnimationes.InjicereVelocitatem(vel);
        }
        public void Purgere() {
            _miPuellaeAnimationes.Purgere();
        }
    }
}


