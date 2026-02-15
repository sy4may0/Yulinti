using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LegatusIndexusPrincipalis : ILegatus, ILegatusIncipabilis, ILegatusIndexusPrincipalis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumIndexusPrincipalis _velumIndexusPrincipalis;

        private Action _aeAdPremereLudusNovus;
        private Action _aeAdPremerePergeLudum;
        private Action _aeAdPremereOneraLudum;
        private Action _aeAdPremereOptiones;
        private Action _aeAdPremereExi;

        public LegatusIndexusPrincipalis(
            ITurrisMundus turrisMundus,
            IVelumIndexusPrincipalis velumIndexusPrincipalis
        ) {
            _turrisMundus = turrisMundus;
            _velumIndexusPrincipalis = velumIndexusPrincipalis;

            _aeAdPremereLudusNovus = AdPremereLudusNovus;
            _aeAdPremerePergeLudum = AdPremerePergeLudum;
            _aeAdPremereOneraLudum = AdPremereOneraLudum;
            _aeAdPremereOptiones = AdPremereOptiones;
            _aeAdPremereExi = AdPremereExi;
        }

        public void Incipere() {
            _velumIndexusPrincipalis.DemittereIndexusPrincipalis();
            _velumIndexusPrincipalis.AdPremereLudusNovus(_aeAdPremereLudusNovus);
            _velumIndexusPrincipalis.AdPremerePergeLudum(_aeAdPremerePergeLudum);
            _velumIndexusPrincipalis.AdPremereOneraLudum(_aeAdPremereOneraLudum);
            _velumIndexusPrincipalis.AdPremereOptiones(_aeAdPremereOptiones);
            _velumIndexusPrincipalis.AdPremereExi(_aeAdPremereExi);
        }

        private void AdPremereLudusNovus() {
            Notarius.Memorare("未実装: 仮でTestSceneに遷移");
            _turrisMundus.AdMudum(IDMundi.MundusTestScene);
        }

        private void AdPremerePergeLudum() {
            Notarius.Memorare("未実装: PostularePergeLudum");
        }

        private void AdPremereOneraLudum() {
            Notarius.Memorare("未実装: PostulareOneraLudum");
        }

        private void AdPremereOptiones() {
            Notarius.Memorare("未実装: PostulareOptiones");
        }

        private void AdPremereExi() {
            Notarius.Memorare("未実装: PostulareExi");
        }
    }
}