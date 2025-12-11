using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusPuellaeStatusCorporis {
        IDStatus IdStatusActualis { get; }
        IDStatus IdStatusProximus { get; }
        Func<IResFluidaPuellaeMotusLegibile, bool> Conditio { get; }
    }
}