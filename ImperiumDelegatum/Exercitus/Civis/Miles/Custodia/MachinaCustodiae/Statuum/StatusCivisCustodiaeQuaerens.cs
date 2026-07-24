using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeQuaerens : StatusCivisCustodiaeAttendens {
        private readonly IConfiguratioCivisCustodiaeStatusQuaerens _configuratio;

        public StatusCivisCustodiaeQuaerens(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisCustodiaeStatusQuaerens configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resFluidaCivisCustodiae,
            carrus,
            temporis,
            configuratio
        ) {
            _configuratio = configuratio;
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Quaerens
            );
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtStudium: -_configuratio.DeminutioStudiumAdCassationemSec * Temporis.Intervallum
            );
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) >= ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Spectans;
            }

            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) <= 0.0f) {
                return IDCivisStatusCustodiae.Refrigeratio;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}