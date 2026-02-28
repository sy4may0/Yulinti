using Yulinti.Unity.Contractus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Unity.Velum {
    internal sealed class OratorRadicis : IOratorRadicis {
        private readonly IVelumIncipabilisRadicis[] _velumIncipabilis;
        private readonly IVelumPulsabilisRadicis[] _velumPulsabilis;
        private readonly IVelumPulsabilisFixusRadicis[] _velumPulsabilisFixus;
        private readonly IVelumPulsabilisTardusRadicis[] _velumPulsabilisTardus;
        private readonly IVelumLiberabilisRadicis[] _velumLiberabilis;

        public OratorRadicis(
            IReadOnlyList<IVelumIncipabilisRadicis> velumIncipabilis,
            IReadOnlyList<IVelumPulsabilisRadicis> velumPulsabilis,
            IReadOnlyList<IVelumPulsabilisFixusRadicis> velumPulsabilisFixus,
            IReadOnlyList<IVelumPulsabilisTardusRadicis> velumPulsabilisTardus,
            IReadOnlyList<IVelumLiberabilisRadicis> velumLiberabilis
        ) {
            _velumIncipabilis = velumIncipabilis.ToArray();
            _velumPulsabilis = velumPulsabilis.ToArray();
            _velumPulsabilisFixus = velumPulsabilisFixus.ToArray();
            _velumPulsabilisTardus = velumPulsabilisTardus.ToArray();
            _velumLiberabilis = velumLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (IVelumIncipabilisRadicis velum in _velumIncipabilis) {
                velum.Incipere();
            }
        }

        public void Pulsus() {
            foreach (IVelumPulsabilisRadicis velum in _velumPulsabilis) {
                velum.Pulsus();
            }
        }

        public void PulsusFixus() {
            foreach (IVelumPulsabilisFixusRadicis velum in _velumPulsabilisFixus) {
                velum.PulsusFixus();
            }
        }

        public void PulsusTardus() {
            foreach (IVelumPulsabilisTardusRadicis velum in _velumPulsabilisTardus) {
                velum.PulsusTardus();
            }
        }

        public void Liberare() {
            foreach (IVelumLiberabilisRadicis velum in _velumLiberabilis) {
                velum.Liberare();
            }
        }
    }
}