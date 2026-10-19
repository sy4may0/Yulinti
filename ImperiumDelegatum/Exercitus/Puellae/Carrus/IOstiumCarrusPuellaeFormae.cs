using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellaeFormae {
        void PostulareFormae(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
        );
    }
}
