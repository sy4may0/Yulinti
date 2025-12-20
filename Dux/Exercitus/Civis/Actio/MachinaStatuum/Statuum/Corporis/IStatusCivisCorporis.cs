using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusCivisCorporis {
        IDStatusCorporis Id { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        void Intrare(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adInitium);
        void Exire(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adFinem);
    }
}