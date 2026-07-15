using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisOrnamenti : IOperatioPortusConstructionisOrnamenti {
        private Action<UsusPortusConstructionisOrnamenti> _revocatio;
        private Action<UsusPortusConstructionisOrnamenti, float> _revocatioValoris;

        public OperatioPortusConstructionisOrnamenti() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisOrnamenti> revocatio,
            Action<UsusPortusConstructionisOrnamenti, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisOrnamenti usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisOrnamenti usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
