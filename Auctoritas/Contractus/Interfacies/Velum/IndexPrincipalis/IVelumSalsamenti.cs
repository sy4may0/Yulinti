using System.Collections.Generic;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumSalsamenti {
        // UIを表示
        void DemittereSalsamenti();
        // UIを非表示
        void TollereSalsamenti();

        void ActivareUsus(UsusSalsamenti usus);
        void DeactivareUsus(UsusSalsamenti usus);

        // リストをリロード
        void RenovareTablaeManualis(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis);
        void RenovareTablaeAutomaticus(IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus);
    }
}
