using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeNihil : IStatusCivisCustodiae {
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly IResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;
        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuumVisae;
        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        
        // 後で設定に移行する。
        private readonly float _augmentumAuditaeSec = 0.01f;
        private readonly float _deminutioAuditaeSec = 0.01f;
        private readonly float _augmentumVisaeSec = 0.01f;
        private readonly float _deminutioVisaeSec = 0.01f;


        public StatusCivisCustodiaeNihil(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis
        ) {
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _resolutorCivisIctuumAuditae = resolutorCivisIctuumAuditae;
            _resolutorCivisIctuumVisae = resolutorCivisIctuumVisae;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _carrus = carrus;
            _temporis = temporis;
        }

        public void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // ここがVisa/Audita増減の起点ステート, 値とAbaciを初期化する。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: -1.0f,
                dtAudita: -1.0f,
                dtStudium: -1.0f
            );
            abaciCivisStatus.Purgere(idCivis);
        }

        public void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        private float ResolvereAuditam(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            bool estAugere = (
                _resolutorCivisDistantia.EstCustodiaeAuditae(idCivis) &&
                _resolutorCivisIctuumAuditae.EstAudita(idCivis)
            );

            // Abacusの切り替えを解決する。
            abaciCivisStatus.ResolvereDirectionemAuditae(idCivis, estAugere, _temporis.Intervallum);

            if (estAugere) {
                float augmentumAuditae = ResolutorCivisStatus.AugereAuditam(
                    _augmentumAuditaeSec,
                    _resFluidaCivisVeletudinis.Auditus(idCivis),
                    _resolutorCivisIctuumAuditae.Audita(idCivis),
                    abaciCivisStatus.StudiumHabereAuditae(idCivis),
                    _temporis.Intervallum
                );
                return augmentumAuditae;
            } else {
                float deminutioAuditae = ResolutorCivisStatus.DeminuereAuditam(
                    _deminutioAuditaeSec,
                    abaciCivisStatus.StudiumAmittereAuditae(idCivis),
                    _temporis.Intervallum
                );
                return -deminutioAuditae;
            }
        }

        public float ResolvereVisae(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            bool estAugere = (
                _resolutorCivisDistantia.EstCustodiaeVisae(idCivis) &&
                _resolutorCivisIctuumVisae.EstVisa(idCivis)
            );

            // Abacusの切り替えを解決する。
            abaciCivisStatus.ResolvereDirectionemVisae(idCivis, estAugere, _temporis.Intervallum);

            if (estAugere) {
                float augmentumVisae = ResolutorCivisStatus.AugereVisae(
                    _augmentumVisaeSec,
                    _resolutorCivisIctuumVisae.RatioVisus(idCivis),
                    _resFluidaCivisVeletudinis.Visus(idCivis),
                    _resFluidaPuellaeVeletudinis.RatioClaritas,
                    _resFluidaPuellaeVeletudinis.RatioAnomaliae,
                    abaciCivisStatus.StudiumHabereVisae(idCivis),
                    _temporis.Intervallum
                );
                return augmentumVisae;
            } else {
                float deminutioVisae = ResolutorCivisStatus.DeminuereVisae(
                    _deminutioVisaeSec,
                    abaciCivisStatus.StudiumAmittereVisae(idCivis),
                    _temporis.Intervallum
                );
                return -deminutioVisae;
            }
        }

        public void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // audita増減
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtAudita: ResolvereAuditam(idCivis, abaciCivisStatus)
            );
            // visa増減
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: ResolvereVisae(idCivis, abaciCivisStatus)
            );
        }
    }
}