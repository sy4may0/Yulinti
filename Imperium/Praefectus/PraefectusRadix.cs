using VContainer.Unity;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Imperium.Praefectus {
    public sealed class PraefectusRadicis: IStartable, ITickable, ILateTickable, IDisposable {
        private ITurrisMundus _turrisMundus;
        private IOratorRadicis _orator;
        private IMonsAltus _monsAltus;
        private IDuxExercitusRadicis _ducisExercitus;

        public PraefectusRadicis(
            ITurrisMundus turrisMundus,
            IOratorRadicis orator,
            IMonsAltus monsAltus,
            IDuxExercitusRadicis ducisExercitus
        ) {
            _turrisMundus = turrisMundus;
            _orator = orator;
            _monsAltus = monsAltus;
            _ducisExercitus = ducisExercitus;
        }

        // Radixは即時メニュー画面に遷移する。以降このシーンには遷移しない。
        public void Start() {
            _monsAltus.Incipere();
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
            _monsAltus.PulsusTardus();
        }

        public void Dispose() {
            try {
                _ducisExercitus.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _monsAltus.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
        }
    }
}