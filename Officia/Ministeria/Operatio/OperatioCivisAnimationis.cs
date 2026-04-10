using System;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OperatioCivisAnimationis : IOperatioInitiumCivis {
        private Action<int> _revocatioInitiumCivis;

        public OperatioCivisAnimationis() {
            _revocatioInitiumCivis = null;
        }

        public void Initiare(
            Action<int> revocatioInitiumCivis
        ) {
            _revocatioInitiumCivis = revocatioInitiumCivis;
        }

        public void Purgare() {
            _revocatioInitiumCivis = null;
        }

        public void Executare(int idCivis) {
            _revocatioInitiumCivis?.Invoke(idCivis);
        }
    }
}