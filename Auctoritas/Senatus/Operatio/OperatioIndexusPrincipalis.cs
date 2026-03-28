using Yulinti.Auctoritas.Contractus;
using System;

// コールバック管理クラス。
namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioIndexusPrincipalis : IOperatioIndexusPrincipalis {
        private Action<UsusIndexusPrincipalis> _revocatio;

        public OperatioIndexusPrincipalis() {
            _revocatio = null;
        }

        public void Initiare(Action<UsusIndexusPrincipalis> revocatio) {
            _revocatio = revocatio;
        }

        public void Purgare(Action<UsusIndexusPrincipalis> revocatio) {
            _revocatio = null;
        }

        public void Executare(UsusIndexusPrincipalis usus) {
            _revocatio?.Invoke(usus);
        }
    }
}