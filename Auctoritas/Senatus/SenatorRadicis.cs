using Yulinti.Auctoritas.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class SenatorRadicis : ISenatorRadicis {
        private readonly IPraecoIncipabilisRadicis[] _praecosIncipabilis;
        private readonly IPraecoLiberabilisRadicis[] _praecosLiberabilis;

        public SenatorRadicis(
            IReadOnlyList<IPraecoIncipabilisRadicis> praecosIncipabilis,
            IReadOnlyList<IPraecoLiberabilisRadicis> praecosLiberabilis
        ) {
            _praecosIncipabilis = praecosIncipabilis.ToArray();
            _praecosLiberabilis = praecosLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IPraecoIncipabilisRadicis praeco in _praecosIncipabilis) {
                praeco.Incipere();
            }
        }

        public void Liberare() {
            foreach (IPraecoLiberabilisRadicis praeco in _praecosLiberabilis) {
                praeco.Liberare();
            }
        }
    }
}