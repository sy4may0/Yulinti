using Yulinti.Officia.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Officia.Turris {
    internal sealed class MonsAltus : IMonsAltus {
        private readonly ITurrisIncipabilis[] _turrisIncipabilis;
        private readonly ITurrisPulsabilis[] _turrisPulsabilis;
        private readonly ITurrisPulsabilisFixus[] _turrisPulsabilisFixus;
        private readonly ITurrisPulsabilisTardus[] _turrisPulsabilisTardus;
        private readonly ITurrisLiberabilis[] _turrisLiberabilis;

        public MonsAltus(
            IReadOnlyList<ITurrisIncipabilis> turrisIncipabilis,
            IReadOnlyList<ITurrisPulsabilis> turrisPulsabilis,
            IReadOnlyList<ITurrisPulsabilisFixus> turrisPulsabilisFixus,
            IReadOnlyList<ITurrisPulsabilisTardus> turrisPulsabilisTardus,
            IReadOnlyList<ITurrisLiberabilis> turrisLiberabilis
        ) {
            _turrisIncipabilis = turrisIncipabilis.ToArray();
            _turrisPulsabilis = turrisPulsabilis.ToArray();
            _turrisPulsabilisFixus = turrisPulsabilisFixus.ToArray();
            _turrisPulsabilisTardus = turrisPulsabilisTardus.ToArray();
            _turrisLiberabilis = turrisLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (ITurrisIncipabilis turris in _turrisIncipabilis) {
                turris.Incipere();
            }
        }

        public void Pulsus() {
            foreach (ITurrisPulsabilis turris in _turrisPulsabilis) {
                turris.Pulsus();
            }
        }

        public void PulsusFixus() {
            foreach (ITurrisPulsabilisFixus turris in _turrisPulsabilisFixus) {
                turris.PulsusFixus();
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