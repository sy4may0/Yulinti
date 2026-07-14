using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortus : IOperatioPortus, IOperatioInternaPortus {
        private Action<UsusPortus> _revocatio;
        private Action _adExireConstructionem;

        public OperatioPortus() {
            _revocatio = null;
            _adExireConstructionem = null;
        }

        public void Initiare(
            Action<UsusPortus> revocatio,
            Action adExireConstructionem
        ) {
            _revocatio = revocatio;
            _adExireConstructionem = adExireConstructionem;
        }

        public void Purgare() {
            _revocatio = null;
            _adExireConstructionem = null;
        }

        public void Executare(UsusPortus usus) {
            _revocatio?.Invoke(usus);
        }

        public void ExireConstructionem() {
            _adExireConstructionem?.Invoke();
        }
    }
}