using Yulinti.ImperiumDelegatum.Contractus;
using System.Threading;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumSignumCancellationisLegibile : IOstiumSignumCancellationisLegibile {
        private readonly MinisteriumSignumCancellationis _signumCancellationis;

        public OstiumSignumCancellationisLegibile(MinisteriumSignumCancellationis signumCancellationis) {
            _signumCancellationis = signumCancellationis;
        }

        public CancellationToken Signum => _signumCancellationis.Signum;
    }
}