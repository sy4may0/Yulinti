using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellaeFigurae {
        void PostulareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        );

        void PostulareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        );
    }
}
