using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortus : IOperatioPortus {
        private Action<UsusPortus> _revocatio;

        public OperatioPortus() {
            _revocatio = null;
        }

        public void Initiare(Action<UsusPortus> revocatio) {
            _revocatio = revocatio;
        }

        public void Purgare(Action<UsusPortus> revocatio) {
            _revocatio = null;
        }

        public void Executare(UsusPortus usus) {
            _revocatio?.Invoke(usus);
        }
    }
}