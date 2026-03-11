using Yulinti.Officia.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Officia.Velum {
    internal sealed class Orator : IOrator {
        private readonly IVelumIncipabilis[] _velumIncipabilis;
        private readonly IVelumLiberabilis[] _velumLiberabilis;

        public Orator(
            IReadOnlyList<IVelumIncipabilis> velumIncipabilis,
            IReadOnlyList<IVelumLiberabilis> velumLiberabilis
        ) {
            _velumIncipabilis = velumIncipabilis.ToArray();
            _velumLiberabilis = velumLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IVelumIncipabilis velum in _velumIncipabilis) {
                velum.Incipere();
            }
        }

        public void Liberare() {
            foreach (IVelumLiberabilis velum in _velumLiberabilis) {
                velum.Liberare();
            }
        }
    }
}