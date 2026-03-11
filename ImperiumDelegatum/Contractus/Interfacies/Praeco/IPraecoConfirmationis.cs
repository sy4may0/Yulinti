using System;
using System.Threading;
using System.Threading.Tasks;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IPraecoConfirmationis {
        void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            IDSonusVeli sonusNon = IDSonusVeli.Exire,
            CancellationToken cancellationToken = default
        );

        Task<bool> DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            IDSonusVeli sonusNon = IDSonusVeli.Exire,
            CancellationToken cancellationToken = default
        );
    }
}