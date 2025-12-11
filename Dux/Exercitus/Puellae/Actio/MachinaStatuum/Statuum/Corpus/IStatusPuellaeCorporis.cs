using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusPuellaeCorporis {
        IDStatus Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        void Intrare(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action adInitium);
        void Exire(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action adFinem);
        OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFuluidaMotus);
    }
}