using Yulinti.Auctoritas.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class Senator : ISenator {
        private readonly IPraecoIncipabilis[] _praecosIncipabilis;
        private readonly IPraecoLiberabilis[] _praecosLiberabilis;

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
    }
}