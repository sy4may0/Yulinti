using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusCivisCorporis {
        int IdCivis { get; }
        IDCivisStatusCorporis IdStatus { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        int ConsumptioVitae { get; }
        void Intrare(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adInitium);
        void Exire(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adFinem);
        OrdinatioCivisMotus Ordinare(IResFluidaCivisMotusLegibile resFuluidaMotus);
    }
}