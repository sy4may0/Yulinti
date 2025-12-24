using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisStatusCorporis : IRamusCivisStatusCorporis {
        public IDCivisStatusCorporis IdStatusActualis { get; }
        public IDCivisStatusCorporis IdStatusProximus { get; }
        public Func<int, IResFluidaCivisMotusLegibile, bool> Conditio { get; }

        public RamusCivisStatusCorporis(
            IDCivisStatusCorporis idStatusActualis,
            IDCivisStatusCorporis idStatusProximus,
            Func<int, IResFluidaCivisMotusLegibile, bool> conditio
        ) {
            IdStatusActualis = idStatusActualis;
            IdStatusProximus = idStatusProximus;
            Conditio = conditio;
        }
    }
}