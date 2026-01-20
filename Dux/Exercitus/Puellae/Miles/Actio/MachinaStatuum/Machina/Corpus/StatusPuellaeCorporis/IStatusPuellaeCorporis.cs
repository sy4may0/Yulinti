using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusPuellaeCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adInitium
        );
        void Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adFinem
        );
        void Ordinare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
    }
}
