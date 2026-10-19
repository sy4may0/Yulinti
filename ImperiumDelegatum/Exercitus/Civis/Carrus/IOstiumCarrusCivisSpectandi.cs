using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivisSpectandi {
        void PostulareSpectandi(
            int idCivis,
            bool estActivum
        );
    }
}
