using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Exercitus.Dux {
    internal sealed class DuxExercitusRadicis : IDuxExercitusRadicis {
        private readonly ILegatusIncipabilisRadicis[] _legatusIncipabilis;
        private readonly ILegatusPulsabilisRadicis[] _legatusPulsabilis;
        private readonly ILegatusLiberabilisRadicis[] _legatusLiberabilis;

        public DuxExercitusRadicis(
            IReadOnlyList<ILegatusIncipabilisRadicis> legatusIncipabilis,
            IReadOnlyList<ILegatusPulsabilisRadicis> legatusPulsabilis,
            IReadOnlyList<ILegatusLiberabilisRadicis> legatusLiberabilis
        ) {
            _legatusIncipabilis = legatusIncipabilis.ToArray();
            _legatusPulsabilis = legatusPulsabilis.ToArray();
            _legatusLiberabilis = legatusLiberabilis.ToArray();
        }

        public void Incipere() {
            foreach (ILegatusIncipabilisRadicis legatus in _legatusIncipabilis) {
                legatus.Incipere();
            }
        }

        public void Pulsus() {
            foreach (ILegatusPulsabilisRadicis legatus in _legatusPulsabilis) {
                legatus.Pulsus();
            }
        }
        public void PulsusPrimum() {
        }

        public void PulsusFixus() {
        }

        public void PulsusFixusPrimum() {
        }

        public void PulsusTardus() {
        }

        public void PulsusTardusPrimum() {
        }

        public void Liberare() {
            foreach (ILegatusLiberabilisRadicis legatus in _legatusLiberabilis) {
                legatus.Liberare();
            }
        }
    }
}