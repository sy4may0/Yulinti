using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivisAnimationis {
        void PostulareAnimationis(
            int idCivis,
            IDCivisAnimationisStratum stratum,
            IDCivisAnimationis idAnimationis
        );
    }
}
