using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class Ministeria : IMinisteria {
        private readonly FonsTemporis _fonsTemporis;
        private readonly ITemporis _temporis;

        private readonly IMinisteriumPulsabilis[] _ministeriaPulsabilis;
        private readonly IMinisteriumPulsabilisPrimum[] _ministeriaPulsabilisPrimum;
        private readonly IMinisteriumPulsabilisFixus[] _ministeriaPulsabilisFixus;
        private readonly IMinisteriumPulsabilisFixusPrimum[] _ministeriaPulsabilisFixusPrimum;
        private readonly IMinisteriumPulsabilisTardus[] _ministeriaPulsabilisTardus;
        private readonly IMinisteriumPulsabilisTardusPrimum[] _ministeriaPulsabilisTardusPrimum;

        public Ministeria(
            FonsTemporis fonsTemporis,
            ITemporis temporis,
            IReadOnlyList<IMinisteriumPulsabilis> ministeriaPulsabilis,
            IReadOnlyList<IMinisteriumPulsabilisPrimum> ministeriaPulsabilisPrimum,
            IReadOnlyList<IMinisteriumPulsabilisFixus> ministeriaPulsabilisFixus,
            IReadOnlyList<IMinisteriumPulsabilisFixusPrimum> ministeriaPulsabilisFixusPrimum,
            IReadOnlyList<IMinisteriumPulsabilisTardus> ministeriaPulsabilisTardus,
            IReadOnlyList<IMinisteriumPulsabilisTardusPrimum> ministeriaPulsabilisTardusPrimum
        ) {
            _fonsTemporis = fonsTemporis;
            _temporis = temporis;

            _ministeriaPulsabilis = ministeriaPulsabilis.ToArray();
            _ministeriaPulsabilisPrimum = ministeriaPulsabilisPrimum.ToArray();
            _ministeriaPulsabilisFixus = ministeriaPulsabilisFixus.ToArray();
            _ministeriaPulsabilisFixusPrimum = ministeriaPulsabilisFixusPrimum.ToArray();
            _ministeriaPulsabilisTardus = ministeriaPulsabilisTardus.ToArray();
            _ministeriaPulsabilisTardusPrimum = ministeriaPulsabilisTardusPrimum.ToArray();
        }

        public void PulsusPrimum() {
            // ここでDeltaTime更新。　-> 以降でITemporis/OstiumTemporisLegibileにアクセスする
            _fonsTemporis.Pulsus();
            foreach (IMinisteriumPulsabilisPrimum ministeria in _ministeriaPulsabilisPrimum) {
                ministeria.PulsusPrimum();
            }
        }
        public void Pulsus() {
            foreach (IMinisteriumPulsabilis ministeria in _ministeriaPulsabilis) {
                ministeria.Pulsus();
            }
        }

        public void PulsusFixusPrimum() {
            // ここでFixedDeltaTime更新。　-> 以降でITemporis/OstiumTemporisLegibileにアクセスする
            _fonsTemporis.PulsusFixus();
            foreach (IMinisteriumPulsabilisFixusPrimum ministeria in _ministeriaPulsabilisFixusPrimum) {
                ministeria.PulsusFixusPrimum();
            }
        }

        public void PulsusFixus() {
            foreach (IMinisteriumPulsabilisFixus ministeria in _ministeriaPulsabilisFixus) {
                ministeria.PulsusFixus();
            }
        }

        public void PulsusTardusPrimum() {
            foreach (IMinisteriumPulsabilisTardusPrimum ministeria in _ministeriaPulsabilisTardusPrimum) {
                ministeria.PulsusTardusPrimum();
            }
        }

        public void PulsusTardus() {
            foreach (IMinisteriumPulsabilisTardus ministeria in _ministeriaPulsabilisTardus) {
                ministeria.PulsusTardus();
            }
        }
    }
}
        



