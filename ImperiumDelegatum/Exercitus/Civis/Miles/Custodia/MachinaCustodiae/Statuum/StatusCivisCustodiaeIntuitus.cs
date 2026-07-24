using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusCivisCustodiaeIntuitus : StatusCivisCustodiaeAttendens {
        private readonly IConfiguratioCivisCustodiaeStatusIntuitus _configuratio;

        protected IConfiguratioCivisCustodiaeStatusIntuitus ConfiguratioIntuitus => _configuratio;

        protected StatusCivisCustodiaeIntuitus(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisCustodiaeStatusIntuitus configuratio
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

        private float ResolvereIntentionem(
            int idCivis,
            AbaciCivisStatus abaciCivisStatus
        ) {
            float puellaeAnomaliae = ResolutorCivisStatus.CorrigereRatioAnomaliae(
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                idCivis
            );
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);
            float torelantiaAnomaliaeMinima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMinima(idCivis);

            bool estAugere = (
                ResFluidaCivisCustodiae.EstCustodiaeVisae(idCivis) &&
                ResFluidaCivisCustodiae.EstVisa(idCivis) &&
                puellaeAnomaliae <= torelantiaAnomaliaeMaxima &&
                puellaeAnomaliae >= torelantiaAnomaliaeMinima
            );

            abaciCivisStatus.ResolvereDirectionemIntentionis(idCivis, estAugere, Temporis.Intervallum);

            if (estAugere) {
                return ResolutorCivisStatus.AugereIntentionisIntuitus(
                    augmentumIntentionis: _configuratio.AugmentumIntentionisSec,
                    ratio: ResFluidaCivisCustodiae.RatioVisus(idCivis),
                    puellaeAnomalia: puellaeAnomaliae,
                    torelantiaAnomaliaeMaxima: torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima: torelantiaAnomaliaeMinima,
                    abaciCivisStatus.StudiumHabereIntentionis(idCivis),
                    Temporis.Intervallum
                );
            }

            return ResolutorCivisStatus.DeminuereIntentionisIntuitus(
                deminutioIntentionis: _configuratio.DeminutioIntentionisSec,
                abaciCivisStatus.StudiumAmittereIntentionis(idCivis),
                Temporis.Intervallum
            );
        }

        private float ResolvereStudium(
            int idCivis,
            AbaciCivisStatus abaciCivisStatus
        ) {
            float puellaeAnomaliae = ResolutorCivisStatus.CorrigereRatioAnomaliae(
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                idCivis
            );
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);
            float torelantiaAnomaliaeMinima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMinima(idCivis);

            bool estAugere = (
                ResFluidaCivisCustodiae.EstCustodiaeVisae(idCivis) &&
                ResFluidaCivisCustodiae.EstVisa(idCivis) &&
                puellaeAnomaliae <= torelantiaAnomaliaeMaxima &&
                puellaeAnomaliae >= torelantiaAnomaliaeMinima
            );

            abaciCivisStatus.ResolvereDirectionemStudii(idCivis, estAugere, Temporis.Intervallum);

            if (estAugere) {
                return ResolutorCivisStatus.AugereStudiumIntuitus(
                    augmentumStudium: _configuratio.AugmentumStudiumSec,
                    puellaeAnomalia: puellaeAnomaliae,
                    torelantiaAnomaliaeMaxima: torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima: torelantiaAnomaliaeMinima,
                    abaciCivisStatus.StudiumHabereStudii(idCivis),
                    Temporis.Intervallum
                );
            }

            return ResolutorCivisStatus.DeminuereStudiumIntuitus(
                deminutioStudium: _configuratio.DeminutioStudiumSec,
                abaciCivisStatus.StudiumAmittereStudii(idCivis),
                Temporis.Intervallum
            );
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            float puellaeAnomaliae = ResolutorCivisStatus.CorrigereRatioAnomaliae(
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                idCivis
            );
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);

            if (puellaeAnomaliae > torelantiaAnomaliaeMaxima) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -_configuratio.DeminutioStudiumAdRecusationemSec * Temporis.Intervallum
                );
                return;
            }

            if (
                !ResFluidaCivisCustodiae.EstCustodiaeVisae(idCivis) ||
                !ResFluidaCivisCustodiae.EstVisa(idCivis)
            ) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -_configuratio.DeminutioStudiumAdAmittensSec * Temporis.Intervallum
                );
                return;
            }

            float dtIntentio = ResolvereIntentionem(idCivis, abaciCivisStatus);
            float dtStudium = ResolvereStudium(idCivis, abaciCivisStatus);

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: dtIntentio,
                dtStudium: dtStudium
            );
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) <= _configuratio.RatioSuspectaeMinimaAdQuaerens * ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Quaerens;
            }

            if (ResFluidaCivisVeletudinis.Studium(idCivis) <= 0.0f) {
                float pa = ResolutorCivisStatus.CorrigereRatioAnomaliae(
                    ResFluidaPuellaeVeletudinis,
                    ResFluidaCivisVeletudinis,
                    idCivis
                );
                float ta = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);

                if (pa > ta) {
                    return IDCivisStatusCustodiae.Discedens;
                } else {
                    return IDCivisStatusCustodiae.Refrigeratio;
                }
            }

            return IDCivisStatusCustodiae.Nihil;
        }

    }
}
