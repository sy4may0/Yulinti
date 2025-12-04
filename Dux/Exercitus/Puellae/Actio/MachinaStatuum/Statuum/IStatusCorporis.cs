using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusCorporis
    {
        IDStatus Id { get; }
        IDPuellaeAnimationisCorporis IdAnimationis { get; }
        void Intrare(IResFluidaPuellaeMotusLegibile resFluidaMotus);
        void Exire(IResFluidaPuellaeMotusLegibile resFluidaMotus);
        OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFluidaMotus);
    }
}