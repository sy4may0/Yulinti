using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IRamusCivisCorporis : IRamusCivis {
        IDCivisStatusCorporis IdStatusActualis { get; }
        IDCivisStatusCorporis IdStatusProximus { get; }
    }
}