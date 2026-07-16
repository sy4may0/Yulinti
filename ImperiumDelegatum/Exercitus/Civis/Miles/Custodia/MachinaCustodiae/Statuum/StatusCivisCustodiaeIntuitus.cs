using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusCivisCustodiaeIntuitus : StatusCivisCustodiaeAttendens {
        // 後で設定に移行する。
        private readonly float _augmentumIntentionisSec = 0.01f;
        private readonly float _deminutioIntentionisSec = 0.01f;
        private readonly float _augmentumStudiumSec = 0.01f;
        private readonly float _deminutioStudiumSec = 0.01f;
        private readonly float _tempusAdRecsationemMaxima = 5f;
        private readonly float _tempusAdRecsationemMinima = 3f;
        private readonly float _tempusAdAmittensMaxima = 5f;
        private readonly float _tempusAdAmittensMinima = 3f;

        private readonly HorologiumTemere[] _horologiumAdRecsationem;
        private readonly HorologiumTemere[] _horologiumAdAmittens;

        protected StatusCivisCustodiaeIntuitus(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLegibile civis,
            Random random
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resolutorCivisIctuumAuditae,
            resolutorCivisIctuumVisae,
            resolutorCivisDistantia,
            carrus,
            temporis
        ) {
            _horologiumAdRecsationem = new HorologiumTemere[civis.Longitudo];
            _horologiumAdAmittens = new HorologiumTemere[civis.Longitudo];

            for (int i = 0; i < civis.Longitudo; i++) {
                _horologiumAdRecsationem[i] = new HorologiumTemere(
                    _tempusAdRecsationemMinima,
                    _tempusAdRecsationemMaxima,
                    random
                );
                _horologiumAdAmittens[i] = new HorologiumTemere(
                    _tempusAdAmittensMinima,
                    _tempusAdAmittensMaxima,
                    random
                );
            }
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
                    augmentumIntentionis: _augmentumIntentionisSec,
                    ratio: ResolutorCivisIctuumVisae.RatioVisus(idCivis),
                    puellaeAnomalia: puellaeAnomaliae,
                    torelantiaAnomaliaeMaxima: torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima: torelantiaAnomaliaeMinima,
                    abaciCivisStatus.StudiumHabereIntentionis(idCivis),
                    Temporis.Intervallum
                );
            } 

            return ResolutorCivisStatus.DeminuereIntentionisIntuitus(
                deminutioIntentionis: _deminutioIntentionisSec,
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
                    augmentumStudium: _augmentumStudiumSec,
                    puellaeAnomalia: puellaeAnomaliae,
                    torelantiaAnomaliaeMaxima: torelantiaAnomaliaeMaxima,
                    torelantiaAnomaliaeMinima: torelantiaAnomaliaeMinima,
                    abaciCivisStatus.StudiumHabereStudii(idCivis),
                    Temporis.Intervallum
                );
            }

            return ResolutorCivisStatus.DeminuereStudiumIntuitus(
                deminutioStudium: _deminutioStudiumSec,
                abaciCivisStatus.StudiumAmittereStudii(idCivis),
                Temporis.Intervallum
            );
        }

        private void ResolvereRecsationem(int idCivis) {
            if (!_horologiumAdRecsationem[idCivis].EstActivum) {
                _horologiumAdRecsationem[idCivis].Activare();
            }

            if (_horologiumAdRecsationem[idCivis].EstExhaurita(Temporis.Intervallum)) {
                // 一定時間anomalia超過でIntentio/Studiumを0にする。
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtIntentio: -1f,
                    dtStudium: -1f
                );
                _horologiumAdRecsationem[idCivis].Deactivare();
            }
        }

        private void ResolvereAmittens(int idCivis) {
            if (!_horologiumAdAmittens[idCivis].EstActivum) {
                _horologiumAdAmittens[idCivis].Activare();
            }

            // 視認ロストでSuspectaを0にする。
            if (_horologiumAdAmittens[idCivis].EstExhaurita(Temporis.Intervallum)) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtSuspecta: -1f
                );
                _horologiumAdAmittens[idCivis].Deactivare();
            }
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            float puellaeAnomaliae = ResFluidaPuellaeVeletudinis.RatioAnomaliae;
            float torelantiaAnomaliaeMaxima = ResFluidaCivisVeletudinis.RatioTorelantiaAnomaliaeMaxima(idCivis);

            if (puellaeAnomaliae > torelantiaAnomaliaeMaxima) {
                ResolvereRecsationem(idCivis);
            } else {
                _horologiumAdRecsationem[idCivis].Deactivare();
            }

            if (
                !ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) || 
                !ResolutorCivisIctuumVisae.EstVisa(idCivis)
            ) {
                ResolvereAmittens(idCivis);
            } else {
                _horologiumAdAmittens[idCivis].Deactivare();
            }

            float dtIntentio = ResolvereIntentionem(idCivis, abaciCivisStatus);
            float dtStudium = ResolvereStudium(idCivis, abaciCivisStatus);

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: dtIntentio,
                dtStudium: dtStudium
            );
        }
    }
}
