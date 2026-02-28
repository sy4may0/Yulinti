using Yulinti.Unity.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Unity.Velum {
    internal sealed class Orator : IOrator {
        private readonly IVelumIncipabilis[] _velumIncipabilis;
        private readonly IVelumPalsabilis[] _velumPalsabilis;
        private readonly IVelumPalsabilisFixus[] _velumPalsabilisFixus;
        private readonly IVelumPalsabilisTardus[] _velumPalsabilisTardus;
        private readonly IVelumLiberabilis[] _velumLiberabilis;

        public Orator(
            IReadOnlyList<IVelumIncipabilis> velumIncipabilis,
            IReadOnlyList<IVelumPalsabilis> velumPalsabilis,
            IReadOnlyList<IVelumPalsabilisFixus> velumPalsabilisFixus,
            IReadOnlyList<IVelumPalsabilisTardus> velumPalsabilisTardus,
            IReadOnlyList<IVelumLiberabilis> velumLiberabilis
        ) {
            _velumIncipabilis = velumIncipabilis.ToArray();
            _velumPalsabilis = velumPalsabilis.ToArray();
            _velumPalsabilisFixus = velumPalsabilisFixus.ToArray();
            _velumPalsabilisTardus = velumPalsabilisTardus.ToArray();
            _velumLiberabilis = velumLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IVelumIncipabilis velum in _velumIncipabilis) {
                velum.Incipere();
            }
        }

        public void Pulsus() {
            foreach (IVelumPalsabilis velum in _velumPalsabilis) {
                velum.Pulsus();
            }
        }

        public void PulsusFixus() {
            foreach (IVelumPalsabilisFixus velum in _velumPalsabilisFixus) {
                velum.PulsusFixus();
            }
        }

        public void PulsusTardus() {
            foreach (IVelumPalsabilisTardus velum in _velumPalsabilisTardus) {
                velum.PulsusTardus();
            }
        }

        public void Liberare() {
            foreach (IVelumLiberabilis velum in _velumLiberabilis) {
                velum.Liberare();
            }
        }
    }
}