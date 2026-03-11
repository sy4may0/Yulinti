using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisInterpretationis : ITurrisInterpretationis {
        private readonly TablaTextus _tablaTextus;

        public TurrisInterpretationis() {
            _tablaTextus = new TablaTextus();
        }

        public string LegoTextus(IDTextus idTextus) {
            return _tablaTextus.LegoTextus(idTextus);
        }
    }
}