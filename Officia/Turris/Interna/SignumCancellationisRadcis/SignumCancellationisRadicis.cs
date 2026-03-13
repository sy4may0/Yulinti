using System.Threading;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    // Game統括CancellationTokenSource
    internal sealed class SignumCancellationisRadcis : ISignumCancellationisRadicisLegibile {
        private readonly CancellationTokenSource _cancellationTokenSource;

        public SignumCancellationisRadcis() {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public CancellationToken Signum => _cancellationTokenSource.Token;

        public void Cancellare() {
            _cancellationTokenSource.Cancel();
        }
    }
}