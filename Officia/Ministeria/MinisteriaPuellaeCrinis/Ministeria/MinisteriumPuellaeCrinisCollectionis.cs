using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeCrinisCollectionis {
        private readonly TabulaPuellaeCrinisCollectionis _tabula;
        private readonly MinisteriumPuellaeCrinisAnterior _miAnterior;
        private readonly MinisteriumPuellaeCrinisPosterior _miPosterior;
        private readonly MinisteriumPuellaeCrinisBasis _miBasis;

        public MinisteriumPuellaeCrinisCollectionis(
            IConfiguratioPuellaeCrinisCollectionis configuratio,
            MinisteriumPuellaeCrinisAnterior miAnterior,
            MinisteriumPuellaeCrinisPosterior miPosterior,
            MinisteriumPuellaeCrinisBasis miBasis
        ) {
            _tabula = new TabulaPuellaeCrinisCollectionis(configuratio);
            _miAnterior = miAnterior;
            _miPosterior = miPosterior;
            _miBasis = miBasis;
        }

        public void Muto(IDPuellaeCrinisCollectionisAnterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisCollectionisAnterior.Nihil) {
                DeletoAnterior();
                return;
            }

            IConfiguratioPuellaeCrinisCollectionisAnterior descriptio = _tabula.Lego(idCrinis);
            _miAnterior.Muto(descriptio.IDPuellaeCrinisAnterior);
        }

        public void Muto(IDPuellaeCrinisCollectionisPosterior idCrinis) {
            if (idCrinis == IDPuellaeCrinisCollectionisPosterior.Nihil) {
                DeletoPosterior();
                return;
            }

            IConfiguratioPuellaeCrinisCollectionisPosterior descriptio = _tabula.Lego(idCrinis);
            _miBasis.Muto(descriptio.IDPuellaeCrinisBasis);
            _miPosterior.Muto(descriptio.IDPuellaeCrinisPosterior);
        }

        public void DeletoAnterior() {
            _miAnterior.Deleto();
        }

        public void DeletoPosterior() {
            _miBasis.Deleto();
            _miPosterior.Deleto();
        }
    }
}
