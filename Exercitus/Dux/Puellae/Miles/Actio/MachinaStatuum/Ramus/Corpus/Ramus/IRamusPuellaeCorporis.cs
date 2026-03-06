using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IRamusPuellaeCorporis : IRamusPuellae {
        IDPuellaeStatusCorporis IdStatusActualis { get; }
        IDPuellaeStatusCorporis IdStatusProximus { get; }
    }
}
