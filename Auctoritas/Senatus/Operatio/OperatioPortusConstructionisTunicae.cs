using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisTunicae : IOperatioPortusConstructionisTunicae {
        private Action<UsusPortusConstructionisTunicae> _revocatio;
        private Action<UsusPortusConstructionisTunicae, float> _revocatioValoris;

        public OperatioPortusConstructionisTunicae() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisTunicae> revocatio,
            Action<UsusPortusConstructionisTunicae, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisTunicae usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisTunicae usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
