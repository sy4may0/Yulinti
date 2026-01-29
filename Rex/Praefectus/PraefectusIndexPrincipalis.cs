using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;
using System;
using UnityEngine;

namespace Yulinti.Rex {
    public sealed class PraefectusIndexPrincipalis : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private ITurrisMundus _turrisMundus;
        private IOstiumInputVelumLegibile _ostiumInputVelumLegibile;

        public PraefectusIndexPrincipalis(
            ITurrisMundus turrisMundus,
            IOstiumInputVelumLegibile ostiumInputVelumLegibile
        ) {
            _turrisMundus = turrisMundus;
            _ostiumInputVelumLegibile = ostiumInputVelumLegibile;
        }

        public void Start() {
            // メニュー画面
        }

        public void Tick() {
            // 仮構成。 Enterが押されたらTestSceneに遷移
            if (_ostiumInputVelumLegibile.LegoClick) {
                _turrisMundus.AdMudum(IDMundi.MundusTestScene);
            }
        }

        public void FixedTick() {
            // メニュー画面
        }

        public void LateTick() {
            // メニュー画面
        }

        public void Dispose() {
            // メニュー画面
        }
    }
}