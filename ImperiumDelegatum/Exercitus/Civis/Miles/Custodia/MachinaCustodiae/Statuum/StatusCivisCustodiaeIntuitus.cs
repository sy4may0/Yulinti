using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusCivisCustodiaeIntuitus : StatusCivisCustodiaeAttendens {
        private readonly IConfiguratioCivisStatusCustodiaeIntuitus _configuratio;

        protected IConfiguratioCivisStatusCustodiaeIntuitus ConfiguratioIntuitus => _configuratio;

        protected StatusCivisCustodiaeIntuitus(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisStatusCustodiaeIntuitus configuratio
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

        private float ResolvereIntentionem(
            int idCivis,
            AbaciCivisStatus abaciCivisStatus
        ) {
            float puellaeAnomaliae = ResFluidaPuellaeVeletudinis.RatioAnomaliae;
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);
            float torelantiaAnomaliaeMinima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMinima(idCivis);

            bool estAugere = (
                ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) &&
                ResolutorCivisIctuumVisae.EstVisa(idCivis) &&
                puellaeAnomaliae <= torelantiaAnomaliaeMaxima &&
                puellaeAnomaliae >= torelantiaAnomaliaeMinima
            );

            abaciCivisStatus.ResolvereDirectionemIntentionis(idCivis, estAugere, Temporis.Intervallum);

            if (estAugere) {
                return ResolutorCivisStatus.AugereIntentionisIntuitus(
                    augmentumIntentionis: _configuratio.AugmentumIntentionisSec,
                    ratio: ResolutorCivisIctuumVisae.RatioVisus(idCivis),
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
            float puellaeAnomaliae = ResFluidaPuellaeVeletudinis.RatioAnomaliae;
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);
            float torelantiaAnomaliaeMinima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMinima(idCivis);

            bool estAugere = (
                ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) &&
                ResolutorCivisIctuumVisae.EstVisa(idCivis) &&
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

            float puellaeAnomaliae = ResFluidaPuellaeVeletudinis.RatioAnomaliae;
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);

            if (puellaeAnomaliae > torelantiaAnomaliaeMaxima) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -_configuratio.DeminutioStudiumAdRecsationemSec
                );
                return;
            }

            if (
                !ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) ||
                !ResolutorCivisIctuumVisae.EstVisa(idCivis)
            ) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -_configuratio.DeminutioStudiumAdAmittensSec
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
            if (ResFluidaCivisVeletudinis.Studium(idCivis) <= 0.0f) {
                float pa = ResFluidaPuellaeVeletudinis.RatioAnomaliae;
                float ta = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);

                if (pa > ta) {
                    return IDCivisStatusCustodiae.Discedens;
                } else {
                    return IDCivisStatusCustodiae.RefrigeratioVigilantia;
                }
            }

            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) <= 0.4f) {
                return IDCivisStatusCustodiae.Quaerens;
            }

            return IDCivisStatusCustodiae.Nihil;
        }

    }
}
