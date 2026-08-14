using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisFixus, ICenturioPulsabilisTardus, ICenturioLiberabilis {
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly MilesCivisActionis _milesCivisActionis;
        private readonly MilesCivisCustodiae _milesCivisCustodiae;
        private readonly MilesCivisGenerationis _milesCivisGenerationis;
        private readonly MilesCivisVeletudinisMaxima _milesCivisVeletudinisMaxima;
        private readonly MilesCivisPersonae _milesCivisPersonae;
        private readonly OperatioCenturioCivis _operatioCenturioCivis;

        // Carrus
        private readonly CarrusCivis _carrusCivis;
        private readonly CarrusCivisManifestationis _carrusCivisManifestationis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisActionis milesCivisActionis,
            MilesCivisCustodiae milesCivisCustodiae,
            MilesCivisGenerationis milesCivisGenerationis,
            MilesCivisVeletudinisMaxima milesCivisVeletudinisMaxima,
            MilesCivisPersonae milesCivisPersonae,
            IResFluidaCivisLegibile resFluidaLegibile,
            IOstiumCivisLegibile ostiumCivisLegibile,
            CarrusCivis carrusCivis,
            CarrusCivisManifestationis carrusCivisManifestationis,
            OperatioCenturioCivis operatioCenturioCivis
        ) {
            _milesCivisActionis = milesCivisActionis;
            _milesCivisCustodiae = milesCivisCustodiae;
            _milesCivisGenerationis = milesCivisGenerationis;
            _milesCivisVeletudinisMaxima = milesCivisVeletudinisMaxima;
            _milesCivisPersonae = milesCivisPersonae;
            _resFluidaLegibile = resFluidaLegibile;
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _carrusCivis = carrusCivis;
            _carrusCivisManifestationis = carrusCivisManifestationis;
            _operatioCenturioCivis = operatioCenturioCivis;

            _operatioCenturioCivis.Initare(
                AdManifestatio,
                AdIncarnare,
                AdSpirituare,
                AdDeleto
            );
        }

        private void AdManifestatio(int idCivis, IDCivisPersonae idCivisPersonae) {
            // ResFluidaは_carrusCivis.Initare経由で初期化される。(実体を握ってるのがExecutor)
            _carrusCivis.Initare(idCivis);
            _carrusCivis.Primum(idCivis);
            _milesCivisActionis.Initare(idCivis, _resFluidaLegibile);
            _milesCivisCustodiae.Initare(idCivis);
            _milesCivisVeletudinisMaxima.Initare(idCivis);
            _milesCivisPersonae.Initare(idCivis, idCivisPersonae);
            _carrusCivis.ConfirmareIncipabilis(idCivis);
        }

        private void AdIncarnare(int idCivis) {
            // 予約
        }

        private void AdSpirituare(int idCivis) {
            // 予約
        }

        private void AdDeleto(int idCivis) {
            _milesCivisPersonae.Purgare(idCivis);
            _carrusCivis.Purgare(idCivis);
        }

        public void Pulsus() {
            // Generator計画
            _milesCivisGenerationis.Ordinare();

            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                // ActiveでないCivisはスキップ
                if (!_ostiumCivisLegibile.EstActivum(i)) continue;

                _carrusCivis.Primum(i);

                // VeletudinisMaxima計画
                _milesCivisVeletudinisMaxima.Ordinare(i);

                // Personae計画
                _milesCivisPersonae.Ordinare(i);

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
                // 生成/消失の処理は全IDに対して行う。
                _carrusCivis.ConfirmareMortis(i);

                if (!_ostiumCivisLegibile.EstActivum(i)) continue;

                _carrusCivis.ConfirmareTardus(i);
            }

            _carrusCivisManifestationis.Confirmare();
        }

        public void Liberare() {
            _milesCivisGenerationis.Liberare();
            _carrusCivisManifestationis.Purgare();
        }
    }
}
