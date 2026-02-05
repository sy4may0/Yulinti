using System;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeAnimationesMutabile {
        void Postulare(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem);
        void Cogere(IDPuellaeAnimationisContinuata idContinuata, Action adInitium, Action adFinem);
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
        void Purgere();
    }
}


