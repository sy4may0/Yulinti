using VContainer.Unity;
using Yulinti.Officia.Contractus;
using System;
using UnityEngine;
using Yulinti.Nucleus.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Imperium.Praefectus {
    public sealed class PraefectusIndexPrincipalis : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private IDuxExercitus _duxExercitus;
        private IOrator _orator;

        public PraefectusIndexPrincipalis(
            IOrator orator,
            IDuxExercitus duxExercitus
        ) {
            _orator = orator;
            _duxExercitus = duxExercitus;
        }

        public void Start() {
            _orator.Incipere();
            _duxExercitus.Incipere();
        }

        public void Tick() {
            _orator.Pulsus();
            _duxExercitus.PulsusPrimum();
            _duxExercitus.Pulsus();
        }

        public void FixedTick() {
            _orator.PulsusFixus();
            _duxExercitus.PulsusFixusPrimum();
            _duxExercitus.PulsusFixus();
        }

        public void LateTick() {
            _orator.PulsusTardus();
            _duxExercitus.PulsusTardusPrimum();
            _duxExercitus.PulsusTardus();
        }

        public void Dispose() {
            _duxExercitus.Liberare();
        }
    }
}