using Yulinti.Officia.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Officia.Turris {
    internal sealed class MonsAltus : IMonsAltus {
        private readonly ITurrisIncipabilis[] _turrisIncipabilis;
        private readonly ITurrisPulsabilisTardus[] _turrisPulsabilisTardus;
        private readonly ITurrisLiberabilis[] _turrisLiberabilis;

        public MonsAltus(
            IReadOnlyList<ITurrisIncipabilis> turrisIncipabilis,
            IReadOnlyList<ITurrisPulsabilisTardus> turrisPulsabilisTardus,
            IReadOnlyList<ITurrisLiberabilis> turrisLiberabilis
        ) {
            _turrisIncipabilis = turrisIncipabilis.ToArray();
            _turrisPulsabilisTardus = turrisPulsabilisTardus.ToArray();
            _turrisLiberabilis = turrisLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (ITurrisIncipabilis turris in _turrisIncipabilis) {
                turris.Incipere();
            }
        }

        public void PulsusTardus() {
            foreach (ITurrisPulsabilisTardus turris in _turrisPulsabilisTardus) {
                turris.PulsusTardus();
            }
        }
        
        public void Liberare() {
            foreach (ITurrisLiberabilis turris in _turrisLiberabilis) {
                turris.Liberare();
            }
        }
    }
}