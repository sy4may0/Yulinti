using Yulinti.Officia.Contractus;
using System;

namespace Yulinti.Officia.Velum {
    internal sealed class OperatioAnchoraCivisVelum : IOperatioAnchoraCivis {
        private Action<int, IAnchoraCivis> _revocatioManifestatio;
        private Action<int> _revocatioDeleto;

        public OperatioAnchoraCivisVelum() {
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

        public void ExecutareManifestatio(int idCivis, IAnchoraCivis anchora) {
            _revocatioManifestatio?.Invoke(idCivis, anchora);
        }

        public void ExecutareDeleto(int idCivis) {
            _revocatioDeleto?.Invoke(idCivis);
        }
    }
}