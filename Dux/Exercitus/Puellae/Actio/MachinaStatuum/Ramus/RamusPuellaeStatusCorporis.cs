using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeStatusCorporis : IRamusPuellaeStatusCorporis {
        public IDStatus IdStatusActualis { get; }
        public IDStatus IdStatusProximus { get; }
        public Func<IResFluidaPuellaeMotusLegibile, bool> Conditio { get; }

        public RamusPuellaeStatusCorporis(
            IDStatus idStatusActualis,
            IDStatus idStatusProximus,
            Func<IResFluidaPuellaeMotusLegibile, bool> conditio
        ) {
            IdStatusActualis = idStatusActualis;
            IdStatusProximus = idStatusProximus;
            Conditio = conditio;
        }
    }
}