using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeStatusCorporis : IRamusPuellaeStatusCorporis {
        public IDStatusCorporis IdStatusActualis { get; }
        public IDStatusCorporis IdStatusProximus { get; }
        public Func<IResFluidaPuellaeMotusLegibile, bool> Conditio { get; }

        public RamusPuellaeStatusCorporis(
            IDStatusCorporis idStatusActualis,
            IDStatusCorporis idStatusProximus,
            Func<IResFluidaPuellaeMotusLegibile, bool> conditio
        ) {
            IdStatusActualis = idStatusActualis;
            IdStatusProximus = idStatusProximus;
            Conditio = conditio;
        }
    }
}