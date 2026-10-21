using System.Threading;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    // シーン統括CancellationTokenSource
    // Game統括(Turris)のキャンセルにも連動する。
    internal sealed class SignumCancellationis : ISignumCancellationisLegibile {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly CancellationTokenRegistration _vinculumRadicis;

        public SignumCancellationis(ITurrisSignumCancellationis turrisSignumCancellationis) {
            _cancellationTokenSource = new CancellationTokenSource();
            _vinculumRadicis = turrisSignumCancellationis.Signum.Register(
                () => _cancellationTokenSource.Cancel()
            );
        }

        public CancellationToken Signum => _cancellationTokenSource.Token;

        public void Cancellare() {
            // シーン終了後もRootのTokenに登録が残らないよう解除する。
            _vinculumRadicis.Dispose();
            _cancellationTokenSource.Cancel();
        }
    }
}
