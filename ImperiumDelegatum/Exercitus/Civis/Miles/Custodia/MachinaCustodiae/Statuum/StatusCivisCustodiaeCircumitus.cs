using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeCircumitus : StatusCivisCustodiaeAttendens {
        public StatusCivisCustodiaeCircumitus(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisCustodiaeStatusCircumitus configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resFluidaCivisCustodiae,
            carrus,
            temporis,
            configuratio
        ) {
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // Attendens起点
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Circumitus
            );
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: -ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis),
                dtStudium: -ResFluidaCivisVeletudinis.StudiumMaxima(idCivis),
                dtIntentio: -ResFluidaCivisVeletudinis.IntentioMaxima(idCivis)
            );
            abaciCivisStatus.Purgere(idCivis);
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // ガード
            if (!ResFluidaCivisCustodiae.EstCustodiaeVisae(idCivis) || !ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                return IDCivisStatusCustodiae.Nihil;
            }

            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) >= ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Vigilantia;
            }
            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
