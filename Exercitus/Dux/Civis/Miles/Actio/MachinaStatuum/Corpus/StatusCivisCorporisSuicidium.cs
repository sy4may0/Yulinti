using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class StatusCivisCorporisSuicidium : IStatusCivisCorporis {
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Suicidium;
        public IDCivisAnimationis IdAnimationisIntrare => IDCivisAnimationis.Nihil;
        public IDCivisAnimationis IdAnimationisTransere => IDCivisAnimationis.Nihil;
        public IDCivisAnimationis IdAnimationisExire => IDCivisAnimationis.Nihil;

        public bool EstInterdictaIntrare => false;
        public bool EstInterdictaTransere => false;
        public bool EstInterdictaExire => false;

        public IDCivisStatusCorporis IDStatusProximusAutomaticus => IDCivisStatusCorporis.Suicidium;

        public void Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Transere(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
        }

        public void Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareMortis(
                idCivis, SpeciesOrdinationisCivisMortis.Spirituare
            );
        }
    }
}
