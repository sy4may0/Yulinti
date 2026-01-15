using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusCivisCorporis : IRamusCivis {
        IDCivisStatusCorporis IdStatusActualis { get; }
        IDCivisStatusCorporis IdStatusProximus { get; }
    }
}