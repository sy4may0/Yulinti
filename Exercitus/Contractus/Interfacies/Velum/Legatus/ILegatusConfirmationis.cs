using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Contractus {
    public interface ILegatusConfirmationis {
        void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            CancellationToken cancellationToken = default
        );

        Task<bool> DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            CancellationToken cancellationToken = default
        );
    }
}