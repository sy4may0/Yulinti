using System;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class OperatioSalsamenti : IOperatioSalsamenti {
        private Action<UsusSalsamenti> _revocatio;
        private Action<UsusSalsamenti, Guid> _revocatioGuid;

        public OperatioSalsamenti() {
            _revocatio = null;
            _revocatioGuid = null;
        }

        public void Initiare(
            Action<UsusSalsamenti> revocatio,
            Action<UsusSalsamenti, Guid> revocatioGuid
        ) {
            _revocatio = revocatio;
            _revocatioGuid = revocatioGuid;
        }

        public void Purgare() {
            _revocatio = null;
            _revocatioGuid = null;
        }

        public void Executare(UsusSalsamenti usus) {
            _revocatio?.Invoke(usus);
        }

        public void Executare(UsusSalsamenti usus, Guid id) {
            _revocatioGuid?.Invoke(usus, id);
        }
    }
}