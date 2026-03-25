using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCorporisSuicidium : IStatusCivisCorporis {
        private readonly ContextusStatusCivisCorporis _contextus;
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Suicidium;
        public IDCivisAnimationis IdAnimationisIntrare => IDCivisAnimationis.Nihil;
        public IDCivisAnimationis IdAnimationisTransere => IDCivisAnimationis.Nihil;
        public IDCivisAnimationis IdAnimationisExire => IDCivisAnimationis.Nihil;

        public bool EstInterdictaIntrare => false;
        public bool EstInterdictaTransere => false;
        public bool EstInterdictaExire => false;

        public IDCivisStatusCorporis IDStatusProximusAutomaticus => IDCivisStatusCorporis.Suicidium;

        public StatusCivisCorporisSuicidium(
            ContextusStatusCivisCorporis contextus
        ) {
            _contextus = contextus;
        }

        public void Intrare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Transere(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Exire(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextus.Carrus.PostulareMortis(
                idCivis, SpeciesOrdinationisCivisMortis.Spirituare
            );
        }
    }
}
