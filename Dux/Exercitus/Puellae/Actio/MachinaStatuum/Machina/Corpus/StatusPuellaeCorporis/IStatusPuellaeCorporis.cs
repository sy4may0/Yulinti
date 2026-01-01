using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IStatusPuellaeCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        OrdinatioPuellaeAnimationis Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adInitium
        );
        OrdinatioPuellaeAnimationis Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adFinem
        );
        OrdinatioPuellaeActionis OrdinareActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
        OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
    }
}