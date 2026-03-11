using Yulinti.Officia.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Officia.Velum {
    internal sealed class OratorRadicis : IOratorRadicis {
        private readonly IVelumIncipabilisRadicis[] _velumIncipabilis;
        private readonly IVelumLiberabilisRadicis[] _velumLiberabilis;

        public OratorRadicis(
            IReadOnlyList<IVelumIncipabilisRadicis> velumIncipabilis,
            IReadOnlyList<IVelumLiberabilisRadicis> velumLiberabilis
        ) {
            _velumIncipabilis = velumIncipabilis.ToArray();
            _velumLiberabilis = velumLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IVelumIncipabilisRadicis velum in _velumIncipabilis) {
                velum.Incipere();
            }
        }

        public void Liberare() {
            foreach (IVelumLiberabilisRadicis velum in _velumLiberabilis) {
                velum.Liberare();
            }
        }
    }
}