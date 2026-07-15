using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisLapsorFaciei : IOperatioPortusConstructionisLapsorFaciei {
        private Action<UsusPortusConstructionisLapsorFaciei> _revocatio;
        private Action<UsusPortusConstructionisLapsorFaciei, float> _revocatioValoris;

        public OperatioPortusConstructionisLapsorFaciei() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisLapsorFaciei> revocatio,
            Action<UsusPortusConstructionisLapsorFaciei, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisLapsorFaciei usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisLapsorFaciei usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
