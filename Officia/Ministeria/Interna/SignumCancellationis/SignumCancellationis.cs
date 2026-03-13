using System.Threading;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    // シーン統括CancellationTokenSource
    internal sealed class SignumCancellationis : ISignumCancellationisLegibile {
        private readonly CancellationTokenSource _cancellationTokenSource;

        public SignumCancellationis() {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public CancellationToken Signum => _cancellationTokenSource.Token;

        public void Cancellare() {
            _cancellationTokenSource.Cancel();
        }
    }
}