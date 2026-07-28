using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeSequens : StatusCivisCustodiaeIntuitus {
        public StatusCivisCustodiaeSequens(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisCustodiaeStatusSequens configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resFluidaCivisCustodiae,
            carrus,
            temporis,
            configuratio
        ) {
        }

        public override void Initare(int idCivis, AbaciCivisStatusCustodiae abaciCivisStatus) {
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Sequens
            );
        }

        public override void Exire(int idCivis, AbaciCivisStatusCustodiae abaciCivisStatus) {
        }
    }
}