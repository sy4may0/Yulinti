using Yulinti.Officia.Contractus;
using System;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OperatioAnchoraCivisAnimationes : IOperatioAnchoraCivis {
        private Action<int, IAnchoraCivis> _revocatioManifestatio;
        private Action<int> _revocatioDeleto;

        public OperatioAnchoraCivisAnimationes() {
            _revocatioManifestatio = null;
            _revocatioDeleto = null;
        }

        public void Initiare(
            Action<int, IAnchoraCivis> revocatioManifestatio,
            Action<int> revocatioDeleto
        ) {
            _revocatioManifestatio = revocatioManifestatio;
            _revocatioDeleto = revocatioDeleto;
        }

        public void Purgare() {
            _revocatioManifestatio = null;
            _revocatioDeleto = null;
        }

        public void ExecutareManifestatio(int id, IAnchoraCivis anchora) {
            _revocatioManifestatio?.Invoke(id, anchora);
        }

        public void ExecutareDeleto(int id) {
            _revocatioDeleto?.Invoke(id);
        }
    }
}