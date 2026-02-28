using System;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumCivisAnimationesMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        void Purgere(int id);
        bool EstActivum(int id);
        void Postulare(
            int id,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem
        );
        void Cogere(
            int id,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium,
            Action adFinem
        );
        void TemporareLuditores(int id);
        void InjicereVelocitatem(int id, float vel);
    }
}