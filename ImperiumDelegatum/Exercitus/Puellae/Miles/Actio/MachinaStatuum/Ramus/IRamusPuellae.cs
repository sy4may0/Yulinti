using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IRamusPuellae {
        int Prioritas { get; }
        bool Condicio(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
    }
}
