using VContainer.Unity;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Regnum.Praefectus {
    public sealed class PraefectusRadicis: IStartable, ITickable, ILateTickable, IDisposable {
        private ITurrisMundus _turrisMundus;
        private IOratorRadicis _orator;
        private IDuxExercitusRadicis _ducisExercitus;

        public PraefectusRadicis(
            ITurrisMundus turrisMundus,
            IOratorRadicis orator,
            IDuxExercitusRadicis ducisExercitus
        ) {
            _turrisMundus = turrisMundus;
            _orator = orator;
            _ducisExercitus = ducisExercitus;
        }

        // Radixは即時メニュー画面に遷移する。以降このシーンには遷移しない。
        public void Start() {
            _ducisExercitus.Incipere();
            _turrisMundus.AdMudum(IDMundi.MundusMenu);
        }

        public void Tick() {
            _orator.Pulsus();
            _ducisExercitus.Pulsus();
        }

        public void LateTick() {
            _orator.PulsusTardus();
            _ducisExercitus.PulsusTardus();
        }

        public void Dispose() {
            _ducisExercitus.Liberare();
        }
    }
}