using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IVelumSalsamenti {
        // UIを表示
        void DemittereSalsamenti();
        // UIを非表示
        void TollereSalsamenti();

        void ActivareButton(ButtonSalsamenti buttonSalsamenti);
        void DeactivateButton(ButtonSalsamenti buttonSalsamenti);

        void AdPremereOneraLudum(Action<Guid> ae);
        void AdPremereDeletoLudum(Action<Guid> ae);
        void AdPremereExi(Action ae);
    }
}