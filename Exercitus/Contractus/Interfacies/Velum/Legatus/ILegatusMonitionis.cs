using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Contractus {
    public interface ILegatusMonitionis {
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
