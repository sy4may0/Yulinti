using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusPuellae {
        IDPuellaeStatusCorporis IdStatusActualis { get; }
        IDPuellaeStatusCorporis IdStatusProximus { get; }
        int Prioritas { get; }
        bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        );
    }
}