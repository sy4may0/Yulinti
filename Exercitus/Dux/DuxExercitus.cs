using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Exercitus.Dux {
    internal sealed class DuxExercitus : IDuxExercitus {
        private readonly ICenturioIncipabilis[] _centurioIncipabilis;
        private readonly ICenturioPulsabilis[] _centurioPulsabilis;
        private readonly ICenturioPulsabilisPrimum[] _centurioPulsabilisPrimum;
        private readonly ICenturioPulsabilisFixus[] _centurioPulsabilisFixus;
        private readonly ICenturioPulsabilisFixusPrimum[] _centurioPulsabilisFixusPrimum;
        private readonly ICenturioPulsabilisTardus[] _centurioPulsabilisTardus;
        private readonly ICenturioPulsabilisTardusPrimum[] _centurioPulsabilisTardusPrimum;

        private readonly ILegatusIncipabilis[] _legatusIncipabilis;
        private readonly ILegatusPulsabilis[] _legatusPulsabilis;

        public DuxExercitus(
            IReadOnlyList<ICenturioIncipabilis> centurioIncipabilis,
            IReadOnlyList<ICenturioPulsabilis> centurioPulsabilis,
            IReadOnlyList<ICenturioPulsabilisPrimum> centurioPulsabilisPrimum,
            IReadOnlyList<ICenturioPulsabilisFixus> centurioPulsabilisFixus,
            IReadOnlyList<ICenturioPulsabilisFixusPrimum> centurioPulsabilisFixusPrimum,
            IReadOnlyList<ICenturioPulsabilisTardus> centurioPulsabilisTardus,
            IReadOnlyList<ICenturioPulsabilisTardusPrimum> centurioPulsabilisTardusPrimum,

            IReadOnlyList<ILegatusIncipabilis> legatusIncipabilis,
            IReadOnlyList<ILegatusPulsabilis> legatusPulsabilis
        ) {
            _centurioIncipabilis = centurioIncipabilis.ToArray();
            _centurioPulsabilis = centurioPulsabilis.ToArray();
            _centurioPulsabilisPrimum = centurioPulsabilisPrimum.ToArray();
            _centurioPulsabilisFixus = centurioPulsabilisFixus.ToArray();
            _centurioPulsabilisFixusPrimum = centurioPulsabilisFixusPrimum.ToArray();
            _centurioPulsabilisTardus = centurioPulsabilisTardus.ToArray();
            _centurioPulsabilisTardusPrimum = centurioPulsabilisTardusPrimum.ToArray();

            _legatusIncipabilis = legatusIncipabilis.ToArray();
            _legatusPulsabilis = legatusPulsabilis.ToArray();
        }

        public void Incipere() {
            foreach (ICenturioIncipabilis centurio in _centurioIncipabilis) {
                centurio.Incipere();
            }
            foreach (ILegatusIncipabilis legatus in _legatusIncipabilis) {
                legatus.Incipere();
            }
        }

        public void Pulsus() {
            foreach (ICenturioPulsabilis centurio in _centurioPulsabilis) {
                centurio.Pulsus();
            }
            foreach (ILegatusPulsabilis legatus in _legatusPulsabilis) {
                legatus.Pulsus();
            }
        }
        public void PulsusPrimum() {
            foreach (ICenturioPulsabilisPrimum centurio in _centurioPulsabilisPrimum) {
                centurio.PulsusPrimum();
            }
        }

        public void PulsusFixus() {
            foreach (ICenturioPulsabilisFixus centurio in _centurioPulsabilisFixus) {
                centurio.PulsusFixus();
            }
        }

        public void PulsusFixusPrimum() {
            foreach (ICenturioPulsabilisFixusPrimum centurio in _centurioPulsabilisFixusPrimum) {
                centurio.PulsusFixusPrimum();
            }
        }

        public void PulsusTardus() {
            foreach (ICenturioPulsabilisTardus centurio in _centurioPulsabilisTardus) {
                centurio.PulsusTardus();
            }
        }

        public void PulsusTardusPrimum() {
            foreach (ICenturioPulsabilisTardusPrimum centurio in _centurioPulsabilisTardusPrimum) {
                centurio.PulsusTardusPrimum();
            }
        }
    }
}