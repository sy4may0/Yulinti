using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Turris {
    public class TurrisSoniVeli : ITurrisSoniVeli {
        private readonly IAnchoraSoniVeli _anchoraSoniVeli;
        private readonly TabulaSoniVeli _tabulaSoniVeli;

        public TurrisSoniVeli(IAnchoraSoniVeli anchoraSoniVeli, IConfiguratioSonorumVeli configuratioSonorumVeli) {
            _anchoraSoniVeli = anchoraSoniVeli;
            _tabulaSoniVeli = new TabulaSoniVeli(configuratioSonorumVeli);
        }

        public void Sonare(IDSonusVeli idSonusVeli) {
            if (!_tabulaSoniVeli.ConareLego(idSonusVeli, out SonusVeli sonusVeli)) return;
            sonusVeli.Sonare(_anchoraSoniVeli.FonsSoniVeli);
        }
    }
}