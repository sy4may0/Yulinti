using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeStatusCorporis : IRamusPuellaeStatusCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis { get; }
        public IDPuellaeStatusCorporis IdStatusProximus { get; }
        public Func<IResFluidaPuellaeMotusLegibile, bool> Conditio { get; }

        public RamusPuellaeStatusCorporis(
            IDPuellaeStatusCorporis idStatusActualis,
            IDPuellaeStatusCorporis idStatusProximus,
            Func<IResFluidaPuellaeMotusLegibile, bool> conditio
        ) {
            IdStatusActualis = idStatusActualis;
            IdStatusProximus = idStatusProximus;
            Conditio = conditio;
        }
    }
}