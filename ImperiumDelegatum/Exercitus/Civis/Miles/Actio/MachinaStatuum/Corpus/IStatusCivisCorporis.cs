using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
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
            IResFluidaCivisLegibile resFluida
        );
        void Transere(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        );
        void Exire(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        );
        void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        );
    }
}
