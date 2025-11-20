using UnityEngine;

namespace Yulinti.MinisteriaUnity.Interna {
    public sealed class Temporis : ITemporis {
        private readonly FonsTemporis _fonsTemporis;
        public Temporis(FonsTemporis fonsTemporis) {
            if (fonsTemporis == null) {
                ModeratorErrorum.Fatal("FonsTemporisのインスタンスがnullです。");
            }
            _fonsTemporis = fonsTemporis;
        }

        public float Intervallum => _fonsTemporis.Intervallum;
        public float IntervallumFixus => _fonsTemporis.IntervallumFixus;
    }
}