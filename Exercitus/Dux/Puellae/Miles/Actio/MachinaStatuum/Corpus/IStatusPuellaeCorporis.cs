using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Dux {
    internal interface IStatusPuellaeCorporis {
        IDPuellaeStatusCorporis Id { get; }
        // ステート開始時の再生
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        // ステート中の再生
        IDPuellaeAnimationis IdAnimationisTransere { get; }
        // ステート終了時の再生
        IDPuellaeAnimationis IdAnimationisExire { get; }

        bool EstInterdictaIntrare { get; }
        bool EstInterdictaTransere { get; }
        bool EstInterdictaExire { get; }

        IDPuellaeStatusCorporis IdStatusProximusAutomaticus { get; }

        void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        );
        void Transere(
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