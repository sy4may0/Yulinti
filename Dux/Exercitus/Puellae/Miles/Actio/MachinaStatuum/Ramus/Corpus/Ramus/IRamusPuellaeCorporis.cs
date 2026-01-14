using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusPuellaeCorporis : IRamusPuellae {
        IDPuellaeStatusCorporis IdStatusActualis { get; }
        IDPuellaeStatusCorporis IdStatusProximus { get; }
    }
}