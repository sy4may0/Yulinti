using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class Temporis : ITemporis {
        private readonly FonsTemporis _fonsTemporis;
        public Temporis(FonsTemporis fonsTemporis) {
            if (fonsTemporis == null) {
                Errorum.Fatal(IDErrorum.TEMPORIS_INSTANCE_NULL);
            }
            _fonsTemporis = fonsTemporis;
        }

        public float Intervallum => _fonsTemporis.Intervallum;
        public float IntervallumFixus => _fonsTemporis.IntervallumFixus;
    }
}
