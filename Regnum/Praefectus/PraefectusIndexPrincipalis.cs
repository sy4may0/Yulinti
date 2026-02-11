using VContainer.Unity;
using Yulinti.Exercitus.Contractus;
using System;
using UnityEngine;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Regnum.Praefectus {
    public sealed class PraefectusIndexPrincipalis : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        private ITurrisMundus _turrisMundus;
        private ITurrisIntroductionis _turrisIntroductionis;

        public PraefectusIndexPrincipalis(
            ITurrisMundus turrisMundus,
            ITurrisIntroductionis turrisIntroductionis
        ) {
            _turrisMundus = turrisMundus;
            _turrisIntroductionis = turrisIntroductionis;
        }

        public void Start() {
            // メニュー画面
        }

        public void Tick() {
            // 仮構成。 Enterが押されたらTestSceneに遷移
            if (_turrisIntroductionis.LegoClick) {
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