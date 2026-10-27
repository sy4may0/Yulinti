using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumPuellaeCrinisMutabile {
        void Muto(IDPuellaeCrinisCollectionisAnterior idCrinisAnterior);
        void Muto(IDPuellaeCrinisCollectionisPosterior idCrinisPosterior);
        void DeletoPosterior();
        void DeletoAnterior();
    }
}
