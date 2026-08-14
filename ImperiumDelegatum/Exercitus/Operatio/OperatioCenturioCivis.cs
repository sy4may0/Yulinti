using System;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OperatioCenturioCivis : IOperatioCivisGenerationis {
        private Action<int, IDCivisPersonae> _adManifestatio;
        private Action<int> _adIncarnare;
        private Action<int> _adSpirituare;
        private Action<int> _adDeleto;

        public OperatioCenturioCivis(
        ) {
            _adManifestatio = null;
            _adIncarnare = null;
            _adSpirituare = null;
            _adDeleto = null;
        }

        public void Initare(
            Action<int, IDCivisPersonae> adManifestatio,
            Action<int> adIncarnare, 
            Action<int> adSpirituare,
            Action<int> adDeleto
        ) {
            _adManifestatio = adManifestatio;
            _adIncarnare = adIncarnare;
            _adSpirituare = adSpirituare;
            _adDeleto = adDeleto;
        }

        public void ExecutareManifestatio(int idCivis, IDCivisPersonae idCivisPersonae) {
            _adManifestatio?.Invoke(idCivis, idCivisPersonae);
        }

        public void ExecutareIncarnare(int idCivis) {
            _adIncarnare?.Invoke(idCivis);
        }

        public void ExecutareSpirituare(int idCivis) {
            _adSpirituare?.Invoke(idCivis);
        }

        public void ExecutareDeleto(int idCivis) {
            _adDeleto?.Invoke(idCivis);
        }

        public void Purgere() {
            _adIncarnare = null;
            _adSpirituare = null;
        }
    }
}