using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IRamusPuellae {
        int Prioritas { get; }
        bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
    }
}