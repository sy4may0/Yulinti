using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisFixus, ICenturioPulsabilisTardus, ICenturioLiberabilis {
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly MilesCivisActionis _milesCivisActionis;
        private readonly MilesCivisCustodiae _milesCivisCustodiae;
        private readonly MilesCivisGenerationis _milesCivisGenerationis;
        private readonly OperatioCenturioCivis _operatioCenturioCivis;

        // Carrus
        private readonly CarrusCivis _carrusCivis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisActionis milesCivisActionis,
            MilesCivisCustodiae milesCivisCustodiae,
            MilesCivisGenerationis milesCivisGenerationis,
            IResFluidaCivisLegibile resFluidaLegibile,
            IOstiumCivisLegibile ostiumCivisLegibile,
            CarrusCivis carrusCivis,
            OperatioCenturioCivis operatioCenturioCivis
        ) {
            _milesCivisActionis = milesCivisActionis;
            _milesCivisCustodiae = milesCivisCustodiae;
            _resFluidaLegibile = resFluidaLegibile;
            _milesCivisGenerationis = milesCivisGenerationis;
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _carrusCivis = carrusCivis;
            _operatioCenturioCivis = operatioCenturioCivis;

            _operatioCenturioCivis.Initare(AdIncarnare, AdSpirituare);
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

        public void Pulsus() {
            // Generator計画
            _milesCivisGenerationis.Ordinare();

            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                // ActiveでないCivisはスキップ
                if (!_ostiumCivisLegibile.EstActivum(i)) continue;

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
            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                if (!_ostiumCivisLegibile.EstActivum(i)) continue;

                _milesCivisCustodiae.ResolvereIctuum(i);
            }
        }

        public void PulsusTardus() {
            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                if (!_ostiumCivisLegibile.EstActivum(i)) continue;

                // Detectio判定の解決
                _milesCivisCustodiae.ResolvereDetectio(i, _resFluidaLegibile);

                _carrusCivis.ConfirmareTardus(i);
            }
        }

        public void Liberare() {
            _milesCivisGenerationis.Liberare();
        }
    }
}
