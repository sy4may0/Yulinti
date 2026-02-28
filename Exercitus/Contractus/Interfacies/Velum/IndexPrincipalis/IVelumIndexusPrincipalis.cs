using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IVelumIndexusPrincipalis {
        void Initare();

        // タイトルUIを表示
        void DemittereIndexusPrincipalis();
        // タイトルUIを非表示
        void TollereIndexusPrincipalis();

        void ActivareButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis);
        void DeactivareButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis);

        void AdPremereLudusNovus(Action ae);
        void AdPremerePergeLudum(Action ae);
        void AdPremereOneraLudum(Action ae);
        void AdPremereOptiones(Action ae);
        void AdPremereExi(Action ae);
    }
}
