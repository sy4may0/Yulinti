using System;
using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisPulsabulumCrinisPosterior : IOperatioPortusConstructionisPulsabulumCrinisPosterior {
        private Action<IDPuellaeCrinisCollectionisPosterior> _revocatio;

        public OperatioPortusConstructionisPulsabulumCrinisPosterior() {
            _revocatio = null;
        }

        public void Initiare(Action<IDPuellaeCrinisCollectionisPosterior> revocatio) {
            _revocatio = revocatio;
        }

        public void Purgare() {
            _revocatio = null;
        }

        public void Executare(IDPuellaeCrinisCollectionisPosterior id) {
            _revocatio?.Invoke(id);
        }
    }
}