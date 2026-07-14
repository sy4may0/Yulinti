using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionis : IOperatioPortusConstructionis {
        private Action<UsusPortusConstructionis> _revocatio;

        public OperatioPortusConstructionis() {
            _revocatio = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionis> revocatio
        ) {
            _revocatio = revocatio;
        }

        public void Purgare() {
            _revocatio = null;
        }
        
        public void Executare(UsusPortusConstructionis usus) {
            _revocatio?.Invoke(usus);
        }
    }
}