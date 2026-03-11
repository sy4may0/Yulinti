using System;
using System.Threading;
using System.Threading.Tasks;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    public interface IPraecoMonitionis {
        void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            Action adPremereIta = null
        );

        Task DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            CancellationToken cancellationToken = default
        );
    }
}
