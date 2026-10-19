using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivisMortis {
        void PostulareMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        );
    }
}
