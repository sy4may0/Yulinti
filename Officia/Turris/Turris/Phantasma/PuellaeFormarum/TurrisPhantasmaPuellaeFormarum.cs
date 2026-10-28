using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisPhantasmaPuellaeFormarum : ITurrisPhantasmaPuellaeFormarum {
        private readonly PhantasmaPuellaeFormarum _phantasmaPuellaeFormarum;

        public TurrisPhantasmaPuellaeFormarum(
            PhantasmaPuellaeFormarum phantasmaPuellaeFormarum
        ) {
            _phantasmaPuellaeFormarum = phantasmaPuellaeFormarum;
        }

        public void PonoRationem(IDPuellaeFormae idFormae, float ratio) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.PhantasmaPuellaeFormarum_LEGERE_NIHIL);
                return;
            }
            _phantasmaPuellaeFormarum.PonoRationem(idFormae, ratio);
        }
    }
}
