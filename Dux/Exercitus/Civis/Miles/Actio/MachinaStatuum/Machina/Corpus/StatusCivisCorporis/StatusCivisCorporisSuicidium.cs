using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisSuicidium : IStatusCivisCorporis {
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Suicidium;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => IDCivisAnimationisContinuata.NihilCorporis;
        public IDCivisAnimationisContinuata IdAnimationisExire => IDCivisAnimationisContinuata.NihilCorporis;

        public void Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            adInitium?.Invoke();
        }

        public void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            adFinem?.Invoke();
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