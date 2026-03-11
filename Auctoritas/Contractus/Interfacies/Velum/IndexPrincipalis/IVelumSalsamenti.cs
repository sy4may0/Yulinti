using System;
using System.Collections.Generic;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumSalsamenti {
        // UIを表示
        void DemittereSalsamenti();
        // UIを非表示
        void TollereSalsamenti();

        void ActivareButton(ButtonSalsamenti buttonSalsamenti);
        void DeactivareButton(ButtonSalsamenti buttonSalsamenti);

        void AdPremereOneraLudum(Action<Guid> ae);
        void AdPremereDeletoLudum(Action<Guid> ae);
        void AdPremereExi(Action ae);

        // リストをリロード
        void RenovareTablaeManualis(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis);
        void RenovareTablaeAutomaticus(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus);
    }
}
