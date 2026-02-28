using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Contractus {
    public interface ILegatusMonitionis {
        void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null
        );

        Task DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null,
            CancellationToken cancellationToken = default
        );
    }
}
