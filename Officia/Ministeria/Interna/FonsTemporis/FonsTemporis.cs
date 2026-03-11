using UnityEngine;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
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

        // FrameCount
        public int PulsusElapsus() {
            return Time.frameCount;
        }

        public float Intervallum => _intervallum;
        public float IntervallumFixus => _intervallumFixus;
    }
}


