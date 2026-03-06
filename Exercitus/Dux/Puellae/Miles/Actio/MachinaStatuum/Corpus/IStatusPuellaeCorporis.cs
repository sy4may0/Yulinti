using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Dux {
    internal interface IStatusPuellaeCorporis {
        IDPuellaeStatusCorporis Id { get; }
        // ステート開始時の再生
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        // ステート中の再生
        IDPuellaeAnimationis IdAnimationis { get; }
        // ステート終了時の再生
        IDPuellaeAnimationis IdAnimationisExire { get; }

        void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
        void Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
        void Ordinare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
    }
}