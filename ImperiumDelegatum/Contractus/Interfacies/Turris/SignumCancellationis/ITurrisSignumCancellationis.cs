using System.Threading;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface ITurrisSignumCancellationis {
        CancellationToken Signum { get; }
    }
}