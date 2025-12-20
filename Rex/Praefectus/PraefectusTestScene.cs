using VContainer.Unity;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.Exercitus;
using System;

namespace Yulinti.Rex {
    internal sealed class PraefectusTestScene : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private IMinisteria _ministeria;
        private IDuxExercitus _duxExercitus;

        public PraefectusTestScene(
            IMinisteria ministeria,
            IDuxExercitus duxExercitus
        ) {
            _ministeria = ministeria;
            _duxExercitus = duxExercitus;
        }

        public void Start() {
            _ministeria.Incipere();
        }

        public void Tick() {
            _duxExercitus.PulsusPrimum();
            _ministeria.PulsusPrimum();

            _duxExercitus.Pulsus();
            _ministeria.Pulsus();
        }

        public void FixedTick() {
            _duxExercitus.PulsusFixusPrimum();
            _ministeria.PulsusFixusPrimum();

            _duxExercitus.PulsusFixus();
            _ministeria.PulsusFixus();
        }

        public void LateTick() {
            _duxExercitus.PulsusTardusPrimum();
            _ministeria.PulsusTardusPrimum();

            _duxExercitus.PulsusTardus();
            _ministeria.PulsusTardus();
        }

        public void Dispose() {
            _ministeria.Liberare();
        }
    }
}