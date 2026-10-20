using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeCrinisMutabile : IOstiumPuellaeCrinisMutabile {
        private readonly MinisteriumPuellaeCrinisAnterior _miPuellaeCrinisAnterior;
        private readonly MinisteriumPuellaeCrinisPosterior _miPuellaeCrinisPosterior;
        private readonly MinisteriumPuellaeCrinisBasis _miPuellaeCrinisBasis;

        public OstiumPuellaeCrinisMutabile(
            MinisteriumPuellaeCrinisAnterior miPuellaeCrinisAnterior,
            MinisteriumPuellaeCrinisPosterior miPuellaeCrinisPosterior,
            MinisteriumPuellaeCrinisBasis miPuellaeCrinisBasis
        ) {
            if (miPuellaeCrinisAnterior == null
                || miPuellaeCrinisPosterior == null
                || miPuellaeCrinisBasis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeCrinisMutabile_OSTIUMPUELLAECRINISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeCrinisAnterior = miPuellaeCrinisAnterior;
            _miPuellaeCrinisPosterior = miPuellaeCrinisPosterior;
            _miPuellaeCrinisBasis = miPuellaeCrinisBasis;
        }

        public void Muto(IDPuellaeCrinisBasis idCrinisBasis) {
            _miPuellaeCrinisBasis.Muto(idCrinisBasis);
        }

        public void Muto(IDPuellaeCrinisPosterior idCrinisPosterior) {
            _miPuellaeCrinisPosterior.Muto(idCrinisPosterior);
        }

        public void Muto(IDPuellaeCrinisAnterior idCrinisAnterior) {
            _miPuellaeCrinisAnterior.Muto(idCrinisAnterior);
        }

        public void DeletoBasis() {
            _miPuellaeCrinisBasis.Deleto();
        }

        public void DeletoPosterior() {
            _miPuellaeCrinisPosterior.Deleto();
        }

        public void DeletoAnterior() {
            _miPuellaeCrinisAnterior.Deleto();
        }
    }
}
