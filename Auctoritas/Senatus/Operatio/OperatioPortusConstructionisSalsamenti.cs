using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisSalsamenti : IOperatioPortusConstructionisSalsamenti {
        private Action<UsusPortusConstructionisSalsamenti> _revocatio;
        private Action<UsusPortusConstructionisSalsamenti, float> _revocatioValoris;

        public OperatioPortusConstructionisSalsamenti() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisSalsamenti> revocatio,
            Action<UsusPortusConstructionisSalsamenti, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisSalsamenti usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisSalsamenti usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
