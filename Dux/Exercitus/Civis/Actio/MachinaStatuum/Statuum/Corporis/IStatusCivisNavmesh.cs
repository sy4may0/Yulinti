using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusCivisNavmesh {
        int IdCivis { get; }
        IDCivisStatusNavmesh IdStatus { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        int ConsumptioVitae { get; }
        void Intrare(ContextusCivisResFluidaLegibile contextus, Action adInitium);
        void Exire(ContextusCivisResFluidaLegibile contextus, Action adFinem);
        OrdinatioCivisMotus Ordinare(ContextusCivisResFluidaLegibile contextus);
    }
}