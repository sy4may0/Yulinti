// 全UIの統括。
// シーン毎にIVelumTerminabilisを受け取る。
// 全UIの非表示が責務。
// 今は非表示しかないが、全UIに対して何かやりたいときは入れていいけど、最低限のものだけにした方がいいナリよ。
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using System.Collections.Generic;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class CuratorVela { 
        private readonly IReadOnlyList<IVelumTerminabilis> _velumTerminabilis;

        public CuratorVela(IReadOnlyList<IVelumTerminabilis> velumTerminabilis) {
            _velumTerminabilis = velumTerminabilis;
        }

        public void TollereVelaOmnium() {
            foreach (IVelumTerminabilis velum in _velumTerminabilis) {
                velum.TollereFinem();
            }
        }
    }
}