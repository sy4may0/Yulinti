using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisPhantasmaPuellaeCrinis : ITurrisPhantasmaPuellaeCrinis {
        private readonly PhantasmaPuellaeCrinis _phantasmaPuellaeCrinis;

        public TurrisPhantasmaPuellaeCrinis(
            PhantasmaPuellaeCrinis phantasmaPuellaeCrinis
        ) {
            _phantasmaPuellaeCrinis = phantasmaPuellaeCrinis;
        }

        public void PonoCrinisAnterior(IDPuellaeCrinisCollectionisAnterior crinisAnterior) {
            _phantasmaPuellaeCrinis.PonoCrinisAnterior(crinisAnterior);
        }

        public void PonoCrinisPosterior(IDPuellaeCrinisCollectionisPosterior crinisPosterior) {
            _phantasmaPuellaeCrinis.PonoCrinisPosterior(crinisPosterior);
        }
    }
}   