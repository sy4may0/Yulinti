using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeCrinisMutabile : IOstiumPuellaeCrinisMutabile {
        private readonly MinisteriumPuellaeCrinisCollectionis _miPuellaeCrinisCollectionis;

        public OstiumPuellaeCrinisMutabile(
            MinisteriumPuellaeCrinisCollectionis miPuellaeCrinisCollectionis
        ) {
            if (miPuellaeCrinisCollectionis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeCrinisMutabile_OSTIUMPUELLAECRINISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeCrinisCollectionis = miPuellaeCrinisCollectionis;
        }

        public void Muto(IDPuellaeCrinisCollectionisAnterior idCrinisAnterior) {
            _miPuellaeCrinisCollectionis.Muto(idCrinisAnterior);
        }

        public void Muto(IDPuellaeCrinisCollectionisPosterior idCrinisPosterior) {
            _miPuellaeCrinisCollectionis.Muto(idCrinisPosterior);
        }

        public void DeletoPosterior() {
            _miPuellaeCrinisCollectionis.DeletoPosterior();
        }

        public void DeletoAnterior() {
            _miPuellaeCrinisCollectionis.DeletoAnterior();
        }
    }
}
