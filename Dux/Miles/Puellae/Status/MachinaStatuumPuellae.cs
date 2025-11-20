using Yulinti.Dux.Miles.Puellae.Interna;
using Yulinti.Dux.ConfiguratioDucis;
using Yulinti.Dux.ContructusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus.Interfacies;

namespace Yulinti.Dux.Miles.Puellae.Status {
    public sealed class MachinaStatuumPuellae {
        private readonly TabulaStatuumCorporis _tabulaStatuumCorporis;
        private readonly ResFuluidaMotus _resFuluidaMotus;
        private readonly IResFuluidaMotusLegibile _resFuluidaMotusLeg;
        private readonly FasciculusOstiorum _ostia;

        private IStatusCorporis _statusCorporisActualis;
        private IDStatus _statusProximus;

        public MachinaStatuumPuellae(
            FasciculusConfigurationumPuellaeStatus configuratioPuellaeStatus,
            FasciculusOstiorum ostia
        ) {
            _ostia = ostia;
            _tabulaStatuumCorporis = new TabulaStatuumCorporis(configuratioPuellaeStatus, ostia);
            _resFuluidaMotus = new ResFuluidaMotus();
            _resFuluidaMotusLeg = new ResFuluidaMotusLegibile(_resFuluidaMotus);
            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(IDStatus.Quies);

            InitareAnimationem(configuratioPuellaeStatus.Globalis.IdAnimationisFun);
        }

        private void InitareAnimationem(IDPuellaeAnimationisFundamenti idFundamenti) {
            _ostia.PuellaeAnimationesMut.CogereFundamenti(idFundamenti, null, false);
            _ostia.PuellaeAnimationesMut.CogereDesinentiamCorporis();
        }

        public void Opero() {
            // 移動計画を作成
            OrdinatioMotus ordinatio = OrdinareMotum();

            // 移動計画を適用
            ApplicareOrdinationem(ordinatio);

            // 状態更新を検証
            MutareStatumCorporis();

            // 状態更新を適用
            ApplicareMutationis();
        }

        public void OperoRelatum() {
            // FuluidMotusを最新化
            RenovareFuluidaMotus();

            // アニメーションに速度を反映
            _ostia.PuellaeAnimationesMut.InjicereVelocitatem(
                _resFuluidaMotus.VelocitasActualisHorizontal
            );
        }

        private void RenovareFuluidaMotus() {
            _resFuluidaMotus.Renovare(
                _ostia.PuellaeLociLeg.VelHorizontalisPre,
                _ostia.PuellaeLociLeg.VelVerticalisPre,
                _ostia.PuellaeLociLeg.RotatioYPre,
                true // TODO: 現状、ジャンプ無。EstInTerraは常にtrue。
            );
        }

        private OrdinatioMotus OrdinareMotum() {
            return _statusCorporisActualis.Ordinare(_resFuluidaMotusLeg);
        }

        private void ApplicareOrdinationem(OrdinatioMotus ordinatio) {
            _ostia.PuellaeLociMut.AddoVelocitatemHorizontalisLate(
                ordinatio.horizontalis.velocitas,
                ordinatio.horizontalis.tempusLevigatum,
                _ostia.TemporisLeg.Intervallum
            );
            _ostia.PuellaeLociMut.AddoVelocitatemVerticalisLate(
                ordinatio.verticalis.velocitas,
                ordinatio.verticalis.tempusLevigatum,
                _ostia.TemporisLeg.Intervallum
            );
            _ostia.PuellaeLociMut.PonoRotationisYLate(
                ordinatio.rotationisY.rotatioY,
                ordinatio.rotationisY.tempusLevigatum,
                _ostia.TemporisLeg.Intervallum
            );
        }

        private void MutareStatumCorporis() {
            IDStatus prox = _statusCorporisActualis.MutareStatum(_resFuluidaMotusLeg);
            if (_statusCorporisActualis.Id != prox) {
                _statusProximus = prox;
            }
        }

        private void ApplicareMutationis() {
            _statusCorporisActualis.Exire(_resFuluidaMotusLeg);
            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(_statusProximus);
            _statusCorporisActualis.Intrare(_resFuluidaMotusLeg);
        }


    }
}
