using System.Threading;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumSignumCancellationis : IMinisteriumLiberabilis {
        private readonly SignumCancellationis _signumCancellationis;

        public MinisteriumSignumCancellationis(SignumCancellationis signumCancellationis) {
            _signumCancellationis = signumCancellationis;
        }

        public CancellationToken Signum => _signumCancellationis.Signum;

        public void Liberare() {
            _signumCancellationis.Cancellare();
        }
    }
}