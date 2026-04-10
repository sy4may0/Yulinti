using System;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OperatioCenturioCivis : IOperatioCivisGenerationis {
        private Action<int> _adIncarnare;
        private Action<int> _adSpirituare;

        public OperatioCenturioCivis(
        ) {
            _adIncarnare = null;
            _adSpirituare = null;
        }

        public void Initare(Action<int> adIncarnare, Action<int> adSpirituare) {
            _adIncarnare = adIncarnare;
            _adSpirituare = adSpirituare;
        }

        public void ExecutareIncarnare(int idCivis) {
            _adIncarnare?.Invoke(idCivis);
        }

        public void ExecutareSpirituare(int idCivis) {
            _adSpirituare?.Invoke(idCivis);
        }

        public void Purgere() {
            _adIncarnare = null;
            _adSpirituare = null;
        }
    }
}