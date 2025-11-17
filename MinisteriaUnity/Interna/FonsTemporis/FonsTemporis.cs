using UnityEngine;
using Yulinti.Nucleus.Interfacies;

namespace Yulinti.MinisteriaUnity.Interna {
    public sealed class FonsTemporis : IPulsabilis, IPulsabilisFixus {
        private float _intervallum;
        private float _intervalumFixus;

        public FonsTemporis() {
            _intervallum = 0f;
            _intervalumFixus = 0f;
        }

        public void Pulsus() {
            _intervallum = Time.deltaTime;
        }

        public void PulsusFixus() {
            _intervalumFixus = Time.fixedDeltaTime;
        }

        public float Intervalum => _intervallum;
        public float IntervalumFixus => _intervalumFixus;
    }
}