using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusPuellaeCorporis {
        IDStatus Id { get; }
        IDPuellaeAnimationisCorporis IdAnimationis { get; }
        void Intrare(IResFluidaPuellaeMotusLegibile resFuluidaMotus);
        void Exire(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action fInvocanda);
        OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFuluidaMotus);
    }
}