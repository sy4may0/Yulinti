using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class DuxExercitus : IDuxExercitus {
        private readonly ICenturioIncipabilis[] _centurioIncipabilis;
        private readonly ICenturioPulsabilis[] _centurioPulsabilis;
        private readonly ICenturioPulsabilisPrimum[] _centurioPulsabilisPrimum;
        private readonly ICenturioPulsabilisFixus[] _centurioPulsabilisFixus;
        private readonly ICenturioPulsabilisFixusPrimum[] _centurioPulsabilisFixusPrimum;
        private readonly ICenturioPulsabilisTardus[] _centurioPulsabilisTardus;
        private readonly ICenturioPulsabilisTardusPrimum[] _centurioPulsabilisTardusPrimum;

        public DuxExercitus(
            IReadOnlyList<ICenturioIncipabilis> centurioIncipabilis,
            IReadOnlyList<ICenturioPulsabilis> centurioPulsabilis,
            IReadOnlyList<ICenturioPulsabilisPrimum> centurioPulsabilisPrimum,
            IReadOnlyList<ICenturioPulsabilisFixus> centurioPulsabilisFixus,
            IReadOnlyList<ICenturioPulsabilisFixusPrimum> centurioPulsabilisFixusPrimum,
            IReadOnlyList<ICenturioPulsabilisTardus> centurioPulsabilisTardus,
            IReadOnlyList<ICenturioPulsabilisTardusPrimum> centurioPulsabilisTardusPrimum
        ) {
            _centurioIncipabilis = centurioIncipabilis.ToArray();
            _centurioPulsabilis = centurioPulsabilis.ToArray();
            _centurioPulsabilisPrimum = centurioPulsabilisPrimum.ToArray();
            _centurioPulsabilisFixus = centurioPulsabilisFixus.ToArray();
            _centurioPulsabilisFixusPrimum = centurioPulsabilisFixusPrimum.ToArray();
            _centurioPulsabilisTardus = centurioPulsabilisTardus.ToArray();
            _centurioPulsabilisTardusPrimum = centurioPulsabilisTardusPrimum.ToArray();
        }

        public void Incipere() {
            foreach (ICenturioIncipabilis centurio in _centurioIncipabilis) {
                centurio.Incipere();
            }
        }

        public void Pulsus() {
            foreach (ICenturioPulsabilis centurio in _centurioPulsabilis) {
                centurio.Pulsus();
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