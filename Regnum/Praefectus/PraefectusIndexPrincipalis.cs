using VContainer.Unity;
using Yulinti.Unity.Contractus;
using System;
using UnityEngine;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Praefectus {
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
            UnityEngine.Debug.Log("IndexPrincipalis Tick");
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
            try {
                _duxExercitus.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _orator.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
        }
    }
}