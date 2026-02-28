using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Turris {
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