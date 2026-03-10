using VContainer.Unity;
using Yulinti.Unity.Contractus;
using Yulinti.Exercitus.Contractus;
using System;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Regnum.Praefectus {
    public sealed class PraefectusTestScene : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private IMinisteria _ministeria;
        private IDuxExercitus _ducisExercitus;

        public PraefectusTestScene(
            IMinisteria ministeria,
            IDuxExercitus ducisExercitus
        ) {
            _ministeria = ministeria;
            _ducisExercitus = ducisExercitus;
        }

        public void Start() {
            _ducisExercitus.Incipere();
            _ministeria.Incipere();
        }

        public void Tick() {
            _ministeria.PulsusPrimum();
            _ducisExercitus.PulsusPrimum();
            _ministeria.Pulsus();
            _ducisExercitus.Pulsus();
        }

        public void FixedTick() {
            _ministeria.PulsusFixusPrimum();
            _ducisExercitus.PulsusFixusPrimum();
            _ministeria.PulsusFixus();
            _ducisExercitus.PulsusFixus();
        }

        public void LateTick() {
            _ministeria.PulsusTardusPrimum();
            _ducisExercitus.PulsusTardusPrimum();
            _ministeria.PulsusTardus();
            _ducisExercitus.PulsusTardus();
        }

        public void Dispose() {
            try {
                _ministeria.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _ducisExercitus.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
        }
    }
}