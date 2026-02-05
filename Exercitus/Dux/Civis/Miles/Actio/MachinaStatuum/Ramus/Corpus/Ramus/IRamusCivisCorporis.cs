using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IRamusCivisCorporis : IRamusCivis {
        IDCivisStatusCorporis IdStatusActualis { get; }
        IDCivisStatusCorporis IdStatusProximus { get; }
    }
}