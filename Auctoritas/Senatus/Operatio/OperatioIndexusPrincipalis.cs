using Yulinti.Auctoritas.Contractus;
using System;

// コールバック管理クラス。
namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioIndexusPrincipalis : IOperatioIndexusPrincipalis, IOperatioInternaIndexusPrincipalis {
        private Action<UsusIndexusPrincipalis> _revocatio;
        private Action _adRenovareStatumSalsamenti;

        public OperatioIndexusPrincipalis() {
            _revocatio = null;
        }

        public void Initiare(
            Action<UsusIndexusPrincipalis> revocatio,
            Action adRenovareStatumSalsamenti
        ) {
            _revocatio = revocatio;
            _adRenovareStatumSalsamenti = adRenovareStatumSalsamenti;
        }

        public void Purgare() {
            _revocatio = null;
            _adRenovareStatumSalsamenti = null;
        }

        public void Executare(UsusIndexusPrincipalis usus) {
            _revocatio?.Invoke(usus);
        }

        public void RenovareStatumSalsamenti() {
            _adRenovareStatumSalsamenti?.Invoke();
        }
    }
}