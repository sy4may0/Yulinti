using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FonsTemporis : IPulsabilis, IPulsabilisFixus {
        private float _intervallum;
        private float _intervallumFixus;

        public FonsTemporis() {
            _intervallum = 0f;
            _intervallumFixus = 0f;
        }

        public void Pulsus() {
            _intervallum = Time.deltaTime;
        }

        public void PulsusFixus() {
            _intervallumFixus = Time.fixedDeltaTime;
        }

        public float Intervallum => _intervallum;
        public float IntervallumFixus => _intervallumFixus;
    }
}