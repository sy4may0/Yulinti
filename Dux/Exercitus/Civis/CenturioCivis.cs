using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisFixus, ICenturioPulsabilisTardus {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly MilesCivisActionis _milesCivisActionis;
        private readonly MilesCivisCustodiae _milesCivisCustodiae;

        // Carrus
        private readonly CarrusCivis _carrusCivis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisActionis milesCivisActionis,
            MilesCivisCustodiae milesCivisCustodiae,
            IResFluidaCivisLegibile resFluidaLegibile,
            ContextusCivisOstiorumLegibile contextus,
            CarrusCivis carrusCivis
        ) {
            _milesCivisActionis = milesCivisActionis;
            _milesCivisCustodiae = milesCivisCustodiae;
            _resFluidaLegibile = resFluidaLegibile;
            _contextus = contextus;
            _carrusCivis = carrusCivis;

            _carrusCivis.PonoAd(AdIncarnare, AdSpirituare);
        }

        private void AdIncarnare(int idCivis) {
            _carrusCivis.Initare(idCivis);
            _carrusCivis.Primum(idCivis);
            _milesCivisActionis.Initare(idCivis, _resFluidaLegibile);
            _milesCivisCustodiae.Initare(idCivis);
            _carrusCivis.ConfirmareIncipabilis(idCivis);
        }

        private void AdSpirituare(int idCivis) {
            _carrusCivis.Purgare(idCivis);
        }

        // 不整合のNPCが存在すれば修復する。
        private void RenovareDominare(int idCivis) {
            bool estActivum = _contextus.Civis.EstActivum(idCivis);
            bool estDominare = _resFluidaLegibile.Veletudinis.EstDominare(idCivis);

            if (estActivum == estDominare) return;

            if (estActivum) {
                AdIncarnare(idCivis);
            } else {
                AdSpirituare(idCivis);
            }
        }

        public void Pulsus() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                // AdIncarnare/AdSpirituareが生成時にInvoke()されなかった場合に修復する。
                RenovareDominare(i);

                // ActiveでないCivisはスキップ
                if (!_resFluidaLegibile.Veletudinis.EstDominare(i)) continue;

                _carrusCivis.Primum(i);

                // Actionis処理実行
                _milesCivisActionis.MutareStatus(i, _resFluidaLegibile);
                _milesCivisActionis.Ordinare(i, _resFluidaLegibile);

                // 視認度Ordinatio実行
                _milesCivisCustodiae.OrdinareCustodiae(i, _resFluidaLegibile);

                // Carrus適用(Ordinatio実行)
                _carrusCivis.Confirmare(i);
            }
        }

        public void PulsusFixus() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (!_resFluidaLegibile.Veletudinis.EstDominare(i)) continue;

                _milesCivisCustodiae.ResolvereIctuum(i, _resFluidaLegibile);
            }
        }

        public void PulsusTardus() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (!_resFluidaLegibile.Veletudinis.EstDominare(i)) continue;

                // Detectio判定の解決
                _milesCivisCustodiae.ResolvereDetectio(i, _resFluidaLegibile);

                _carrusCivis.ConfirmareTardus(i);
            }
        }
    }
}
