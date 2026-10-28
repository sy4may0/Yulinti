using System;
using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisPulsabulumCrinisAnterior : IOperatioPortusConstructionisPulsabulumCrinisAnterior {
        private Action<IDPuellaeCrinisCollectionisAnterior> _revocatio;

        public OperatioPortusConstructionisPulsabulumCrinisAnterior() {
            _revocatio = null;
        }

        public void Initiare(Action<IDPuellaeCrinisCollectionisAnterior> revocatio) {
            _revocatio = revocatio;
        }

        public void Purgare() {
            _revocatio = null;
        }

        public void Executare(IDPuellaeCrinisCollectionisAnterior id) {
            _revocatio?.Invoke(id);
        }
    }
}