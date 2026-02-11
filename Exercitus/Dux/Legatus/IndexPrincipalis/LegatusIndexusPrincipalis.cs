using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LegatusIndexusPrincipalis : ILegatusIndexusPrincipalis {
        private readonly ITurrisMundus _turrisMundus;

        public LegatusIndexusPrincipalis(
            ITurrisMundus turrisMundus
        ) {
            _turrisMundus = turrisMundus;
        }

        public void PostulareLudusNovus() {
            Notarius.Memorare("未実装: 仮でTestSceneに遷移");
            _turrisMundus.AdMudum(IDMundi.MundusTestScene);
        }

        public void PostularePergeLudum() {
            Notarius.Memorare("未実装: PostularePergeLudum");
        }

        public void PostulareOneraLudum() {
            Notarius.Memorare("未実装: PostulareOneraLudum");
        }

        public void PostulareOptiones() {
            Notarius.Memorare("未実装: PostulareOptiones");
        }

        public void PostulareExi() {
            Notarius.Memorare("未実装: PostulareExi");
        }
    }
}