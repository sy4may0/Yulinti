using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeQuaerens : StatusCivisCustodiaeAttendens {
        private readonly HorologiumTemere[] _horologiumAdCassationem;
        private readonly HorologiumTemere[] _horologiumAdInveniens;

        // 後で設定に移行する。
        private readonly float _tempusAdCassationemMaxima = 8f;
        private readonly float _tempusAdCassationemMinima = 4f;
        private readonly float _tempusAdInveniensMaxima = 1.5f;
        private readonly float _tempusAdInveniensMinima = 0.5f;


        public StatusCivisCustodiaeQuaerens(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumCivisLegibile civis,
            IOstiumTemporisLegibile temporis,
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
            _horologiumAdCassationem = new HorologiumTemere[civis.Longitudo];
            _horologiumAdInveniens = new HorologiumTemere[civis.Longitudo];
            for (int i = 0; i < civis.Longitudo; i++) {
                _horologiumAdCassationem[i] = new HorologiumTemere(
                    _tempusAdCassationemMinima,
                    _tempusAdCassationemMaxima,
                    random
                );
                _horologiumAdInveniens[i] = new HorologiumTemere(
                    _tempusAdInveniensMinima,
                    _tempusAdInveniensMaxima,
                    random
                );
            }
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: -1f
            );
            _horologiumAdCassationem[idCivis].Activare();
            _horologiumAdInveniens[idCivis].Activare();
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            _horologiumAdCassationem[idCivis].Deactivare();
            _horologiumAdInveniens[idCivis].Deactivare();

            // 再度Intuirusに入るためAbaciを初期化する。Intuitusにいかないなら副作用無。
            abaciCivisStatus.PurgereIntentionis(idCivis);
            abaciCivisStatus.PurgereStudii(idCivis);
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            if (_horologiumAdCassationem[idCivis].EstExhaurita(Temporis.Intervallum)) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -1f
                );
                _horologiumAdCassationem[idCivis].Deactivare();
            }

            if (
                ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) && 
                ResolutorCivisIctuumVisae.EstVisa(idCivis)
            ) {
                if (_horologiumAdInveniens[idCivis].EstExhaurita(Temporis.Intervallum)) {
                    Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: 1f
                    );
                    _horologiumAdInveniens[idCivis].Deactivare();
                }
            } else {
                _horologiumAdInveniens[idCivis].Deactivare();
            }
        }
    }
}