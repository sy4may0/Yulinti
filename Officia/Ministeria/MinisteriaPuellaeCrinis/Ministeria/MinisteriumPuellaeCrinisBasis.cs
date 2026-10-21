using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeCrinisBasis {
        private readonly TabulaPuellaeCrinisBasis _tabulaCrinis;
        private IAnchoraPuellaeCrinisBasis _crinisActualis;

        public MinisteriumPuellaeCrinisBasis(IAnchoraPuellaeCrinisBasis[] anchora) {
            _tabulaCrinis = new TabulaPuellaeCrinisBasis(anchora);
            _crinisActualis = null;
        }

        public void Muto(IDPuellaeCrinisBasis idCrinis) {
            if (idCrinis == IDPuellaeCrinisBasis.Nihil) {
                Deleto();
                return;
            }
            if (_crinisActualis != null && _crinisActualis.Typus == idCrinis) {
                return;
            }

            if (_crinisActualis != null) {
                _crinisActualis.Deactivare();
            }
            _crinisActualis = _tabulaCrinis.Lego(idCrinis);
            _crinisActualis.Activare();
        }

        public void Deleto() {
            if (_crinisActualis != null) {
                _crinisActualis.Deactivare();
            }
            _crinisActualis = null;
        }
    }
}
