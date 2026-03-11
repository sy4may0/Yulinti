using System;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumPortus {
        void Initare();

        // タイトルUIを表示
        void DemitterePortus();
        // タイトルUIを非表示
        void TollerePortus();

        void ActivareButton(ButtonPortus buttonPortus);
        void DeactivareButton(ButtonPortus buttonPortus);

        void AdPremereProfectio(Action ae);
        void AdPremereConstructio(Action ae);
        void AdPremereTaberna(Action ae);
        void AdPremereOptiones(Action ae);
        void AdPremereExi(Action ae);
    }
}
