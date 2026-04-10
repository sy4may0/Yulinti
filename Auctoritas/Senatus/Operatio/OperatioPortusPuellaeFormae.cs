using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusPuellaeFormae : IOperatioPortusPuellaeFormae {
        private Action<UsusPortusPuellaeFormae> _revocatio;
        private Action<UsusPortusPuellaeFormae, float> _revocatioRationis;

        public OperatioPortusPuellaeFormae() {
            _revocatio = null;
            _revocatioRationis = null;
        }

        public void Initiare(
            Action<UsusPortusPuellaeFormae> revocatio,
            Action<UsusPortusPuellaeFormae, float> revocatioRationis
        ) {
            _revocatio = revocatio;
            _revocatioRationis = revocatioRationis;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioRationis = null;
        }

        public void Executare(UsusPortusPuellaeFormae usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusPuellaeFormae usus, float ratio) {
            _revocatioRationis?.Invoke(usus, ratio);
        }
    }
}