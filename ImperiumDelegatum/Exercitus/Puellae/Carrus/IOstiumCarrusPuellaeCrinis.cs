using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellaeCrinis {
        void PostulareCrinisBasis(
            IDPuellaeCrinisBasis idCrinisBasis
        );

        void PostulareCrinisAnterior(
            IDPuellaeCrinisAnterior idCrinisAnterior
        );

        void PostulareCrinisPosterior(
            IDPuellaeCrinisPosterior idCrinisPosterior
        );
    }
}
