using Yulinti.Auctoritas.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class Senator : ISenator {
        private readonly IPraecoIncipabilis[] _praecosIncipabilis;
        private readonly IPraecoLiberabilis[] _praecosLiberabilis;
        private readonly IPraecoPulsabilis[] _praecosPulsabilis;
        private readonly IPraecoPulsabilisTardus[] _praecosPulsabilisTardus;

        public Senator(
            IReadOnlyList<IPraecoIncipabilis> praecosIncipabilis,
            IReadOnlyList<IPraecoLiberabilis> praecosLiberabilis
        ) {
            _praecosIncipabilis = praecosIncipabilis.ToArray();
            _praecosLiberabilis = praecosLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IPraecoIncipabilis praeco in _praecosIncipabilis) {
                praeco.Incipere();
            }
        }

        public void Liberare() {
            foreach (IPraecoLiberabilis praeco in _praecosLiberabilis) {
                praeco.Liberare();
            }
        }

        public void Pulsus() {
            foreach (IPraecoPulsabilis praeco in _praecosPulsabilis) {
                praeco.Pulsus();
            }
        }

        public void PulsusTardus() {
            foreach (IPraecoPulsabilisTardus praeco in _praecosPulsabilisTardus) {
                praeco.PulsusTardus();
            }
        }
    }
}