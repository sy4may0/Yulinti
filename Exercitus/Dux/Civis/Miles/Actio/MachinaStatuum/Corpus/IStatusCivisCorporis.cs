using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IStatusCivisCorporis {
        IDCivisStatusCorporis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisTransere { get; }
        IDCivisAnimationis IdAnimationisExire { get; }

        bool EstInterdictaIntrare { get; }
        bool EstInterdictaTransere { get; }
        bool EstInterdictaExire { get; }

        IDCivisStatusCorporis IDStatusProximusAutomaticus { get; }

        void Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        );
        void Transere(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        );
        void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        );
        void Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        );
    }
}
