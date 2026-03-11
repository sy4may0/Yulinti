using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
    internal sealed class PunctumViaeLegibile : IPunctumViaeLegibile {
        private readonly PunctumViae _punctumViae;

        public PunctumViaeLegibile(PunctumViae punctumViae) {
            _punctumViae = punctumViae;
        }

        public int ID => _punctumViae.ID;
        public IDPunctumViaeTypi Typus => _punctumViae.Typus;
        public Vector3 Positio => InterpresNumeri.ToNumerics(_punctumViae.Positio);
        public bool EstActivum => _punctumViae.EstActivum;
    }
}
