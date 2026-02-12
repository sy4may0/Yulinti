using VContainer.Unity;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Praefectus {
    public sealed class PraefectusRadicis: IStartable {
        private ITurrisMundus _turrisMundus;

        public PraefectusRadicis(
            ITurrisMundus turrisMundus
        ) {
            _turrisMundus = turrisMundus;
        }

        // Radixは即時メニュー画面に遷移する。以降このシーンには遷移しない。
        public void Start() {
            _turrisMundus.AdMudum(IDMundi.MundusMenu);
        }
    }
}