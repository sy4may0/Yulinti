using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisSuicidium : IStatusCivisCorporis {
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Suicidium;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => IDCivisAnimationisContinuata.NihilCorporis;
        public IDCivisAnimationisContinuata IdAnimationisExire => IDCivisAnimationisContinuata.NihilCorporis;

        public OrdinatioCivis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            OrdinatioCivisVeletudinisMortis mortis = new OrdinatioCivisVeletudinisMortis(
                idCivis, estSpirituare: true
            );
            return new OrdinatioCivis(
                idCivis, veletudinisMortis: mortis
            );
        }

        public OrdinatioCivis Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            return OrdinatioCivis.Nihil(idCivis);
        }

        public OrdinatioCivis Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            return OrdinatioCivis.Nihil(idCivis);
        }
    }
}