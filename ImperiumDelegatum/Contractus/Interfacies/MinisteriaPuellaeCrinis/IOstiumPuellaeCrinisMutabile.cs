using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumPuellaeCrinisMutabile {
        void Muto(IDPuellaeCrinisBasis idCrinisBasis);
        void Muto(IDPuellaeCrinisPosterior idCrinisPosterior);
        void Muto(IDPuellaeCrinisAnterior idCrinisAnterior);
        void DeletoBasis();
        void DeletoPosterior();
        void DeletoAnterior();
    }
}