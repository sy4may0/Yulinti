using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusCivisStatusCorporis {
        IDCivisStatusCorporis IdStatusActualis { get; }
        IDCivisStatusCorporis IdStatusProximus { get; }
        Func<int, IResFluidaCivisMotusLegibile, bool> Conditio { get; }
    }
}