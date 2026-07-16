using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeVigilantia : IStatusCivisCustodiae {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly Horologium[] _horologiumAdFinem;

        // 後で設定に移行する。
        private readonly float _tempusAdFinemVigilantia = 4f;

        public StatusCivisCustodiaeVigilantia(
            IOstiumCivisLegibile civis,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis
        ) {
            _carrus = carrus;
            _temporis = temporis;

            _horologiumAdFinem = new Horologium[civis.Longitudo];
            for (int i = 0; i < civis.Longitudo; i++) {
                _horologiumAdFinem[i] = new Horologium(
                    _tempusAdFinemVigilantia
                );
            }
        }

        public void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // Suspectaを1に固定する。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: 1.0f,
                dtStudium: 1.0f
            );
            _horologiumAdFinem[idCivis].Activare();
        }

        public void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            _horologiumAdFinem[idCivis].Deactivare();

            // VigilantiaがIntuitusステートの起点。Intentio/Studium関連を初期化する。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: -1.0f,
                dtStudium: -1.0f
            );
            abaciCivisStatus.PurgereStudii(idCivis);
            abaciCivisStatus.PurgereIntentionis(idCivis);
        }

        public void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // horologiumが切れたらstudiumを0にする。
            if (_horologiumAdFinem[idCivis].EstExhaurita(_temporis.Intervallum)) {
                _carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtStudium: -1.0f
                );
            }
        }
    } 
}