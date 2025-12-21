using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusPuellaeStatusCorporis {
        IDPuellaeStatusCorporis IdStatusActualis { get; }
        IDPuellaeStatusCorporis IdStatusProximus { get; }
        Func<IResFluidaPuellaeMotusLegibile, bool> Conditio { get; }
    }
}