using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeSpectans : StatusCivisCustodiaeIntuitus {
        private readonly IConfiguratioCivisStatusCustodiaeSpectans _configuratio;

        public StatusCivisCustodiaeSpectans(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisStatusCustodiaeSpectans configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resolutorCivisIctuumAuditae,
            resolutorCivisIctuumVisae,
            resolutorCivisDistantia,
            carrus,
            temporis,
            configuratio
        ) {
            _configuratio = configuratio;
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Spectans
            );
            // Intuitus起点
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis),
                dtStudium: ResFluidaCivisVeletudinis.StudiumMaxima(idCivis),
                dtIntentio: -ResFluidaCivisVeletudinis.IntentioMaxima(idCivis)
            );
            abaciCivisStatus.PurgereIntentionis(idCivis);
            abaciCivisStatus.PurgereStudii(idCivis);
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            IDCivisStatusCustodiae status = base.MutareStatus(idCivis);
            if (status != IDCivisStatusCustodiae.Nihil) {
                return status;
            }

            if (ResFluidaCivisVeletudinis.Intentio(idCivis) >= _configuratio.RatioIntentionisAdSequens * ResFluidaCivisVeletudinis.IntentioMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Sequens;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}