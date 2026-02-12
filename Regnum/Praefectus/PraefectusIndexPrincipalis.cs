using VContainer.Unity;
using Yulinti.Unity.Contractus;
using System;
using UnityEngine;
using Yulinti.Nucleus.Contractus;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Praefectus {
    public sealed class PraefectusIndexPrincipalis : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private IOrator _orator;

        public PraefectusIndexPrincipalis(
            IOrator orator
        ) {
            _orator = orator;
        }

        public void Start() {
            _orator.Incipere();
        }

        public void Tick() {
            _orator.Pulsus();
        }

        public void FixedTick() {
            _orator.PulsusFixus();
        }

        public void LateTick() {
            _orator.PulsusTardus();
        }

        public void Dispose() {
            // メニュー画面
        }
    }
}