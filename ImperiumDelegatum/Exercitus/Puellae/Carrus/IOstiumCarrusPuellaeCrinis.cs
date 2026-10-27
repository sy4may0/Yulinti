using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusPuellaeCrinis {
        void PostulareCrinisAnterior(
            IDPuellaeCrinisCollectionisAnterior idCrinisAnterior
        );

        void PostulareCrinisPosterior(
            IDPuellaeCrinisCollectionisPosterior idCrinisPosterior
        );
    }
}
