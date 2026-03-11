using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class Temporis : ITemporis {
        private readonly FonsTemporis _fonsTemporis;
        public Temporis(FonsTemporis fonsTemporis) {
            if (fonsTemporis == null) {
                Carnifex.Intermissio(LogTextus.Temporis_TEMPORIS_INSTANCE_NULL);
            }
            _fonsTemporis = fonsTemporis;
        }

        public float Intervallum => _fonsTemporis.Intervallum;
        public float IntervallumFixus => _fonsTemporis.IntervallumFixus;
        public int PulsusElapsus => _fonsTemporis.PulsusElapsus();
    }
}


