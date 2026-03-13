using System.Threading;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisSignumCancellationis : ITurrisSignumCancellationis, ITurrisLiberabilis {
        private readonly SignumCancellationisRadcis _signumCancellationisRadcis;

        public TurrisSignumCancellationis(SignumCancellationisRadcis signumCancellationisRadcis) {
            _signumCancellationisRadcis = signumCancellationisRadcis;
        }

        public CancellationToken Signum => _signumCancellationisRadcis.Signum;

        public void Liberare() {
            _signumCancellationisRadcis.Cancellare();
        }
    }
}