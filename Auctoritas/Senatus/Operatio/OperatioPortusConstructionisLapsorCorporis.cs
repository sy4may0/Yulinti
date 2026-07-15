using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioPortusConstructionisLapsorCorporis : IOperatioPortusConstructionisLapsorCorporis {
        private Action<UsusPortusConstructionisLapsorCorporis> _revocatio;
        private Action<UsusPortusConstructionisLapsorCorporis, float> _revocatioValoris;

        public OperatioPortusConstructionisLapsorCorporis() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Initiare(
            Action<UsusPortusConstructionisLapsorCorporis> revocatio,
            Action<UsusPortusConstructionisLapsorCorporis, float> revocatioValoris
        ) {
            _revocatio = revocatio;
            _revocatioValoris = revocatioValoris;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioValoris = null;
        }

        public void Executare(UsusPortusConstructionisLapsorCorporis usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusPortusConstructionisLapsorCorporis usus, float valor) {
            _revocatioValoris?.Invoke(usus, valor);
        }
    }
}
