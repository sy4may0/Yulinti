using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisSubligaculi : IOperatioPortusConstructionisSubligaculi {
        private Action<UsusPortusConstructionisSubligaculi> _revocatio;
        private Action<UsusPortusConstructionisSubligaculi, float> _revocatioValoris;

        public OperatioPortusConstructionisSubligaculi() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisSubligaculi> revocatio,
            Action<UsusPortusConstructionisSubligaculi, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisSubligaculi usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisSubligaculi usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
