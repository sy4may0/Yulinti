using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 旧SuspectioAuditae/SuspectioVisaeを統合した疑心ステート。
    // Suspecta(疑心度)が疑心域(下限～1.0)にある間の状態。
    // Attendens基底がSuspectaの増減を解決し、当ステートは滞在時間の上限のみ管理する。
    internal sealed class StatusCivisCustodiaeSuspectio : StatusCivisCustodiaeAttendens {
        private readonly HorologiumTemere[] _horologiumAdFinem;

        // 後で設定に移行する。
        private readonly float _tempusAdFinemSuspectioMaxima = 15f;
        private readonly float _tempusAdFinemSuspectioMinima = 8f;

        public StatusCivisCustodiaeSuspectio(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
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
            _horologiumAdFinem = new HorologiumTemere[civis.Longitudo];
            for (int i = 0; i < civis.Longitudo; i++) {
                _horologiumAdFinem[i] = new HorologiumTemere(
                    _tempusAdFinemSuspectioMinima,
                    _tempusAdFinemSuspectioMaxima,
                    random
                );
            }
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            _horologiumAdFinem[idCivis].Activare();
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            _horologiumAdFinem[idCivis].Deactivare();
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            // 滞在時間上限に達したらSuspectaを落とし、冷却(RefrigeratioSuspectio)へ向かわせる。
            if (_horologiumAdFinem[idCivis].EstExhaurita(Temporis.Intervallum)) {
                Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtSuspecta: -1.0f
                );
            }
        }
    }
}
