using Yulinti.Dux.Miles;
using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Miles {
    internal sealed class MachinaStatuumPuellae {
        private readonly TabulaStatuumCorporis _tabulaStatuumCorporis;
        private readonly ResFuluidaMotus _resFuluidaMotus;
        private readonly IResFuluidaMotusLegibile _resFuluidaMotusLeg;
        private readonly Motor _motor;
        private readonly IOstiumPuellaeAnimationesMutabile _osAnimationesMut;
        private readonly IOstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private readonly IOstiumPuellaeLociMutabile _osPuellaeLociMut;

        private IStatusCorporis _statusCorporisActualis;
        private IDStatus _statusProximus;

        private Action _fInvocanda; // LuditorAnimationisに渡すコールバック

        public MachinaStatuumPuellae(
            FasciculusThesaurorumPuellaeStatus thesauriPuellaeStatus,
            FasciculusOstiorumPuellae ostia
        ) {
            _osAnimationesMut = ostia.PuellaeAnimationesMut;
            _osPuellaeLociLeg = ostia.PuellaeLociLeg;
            _osPuellaeLociMut = ostia.PuellaeLociMut;
            _tabulaStatuumCorporis = new TabulaStatuumCorporis(
                thesauriPuellaeStatus,
                ostia.InputMotusLeg,
                ostia.TemporisLeg,
                ostia.CameraPriLeg,
                ostia.ErrorumLeg
            );
            _resFuluidaMotus = new ResFuluidaMotus();
            _resFuluidaMotusLeg = new ResFuluidaMotusLegibile(_resFuluidaMotus);
            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(IDStatus.Quies);
            _fInvocanda = ApplicareMutationis;

            InitareAnimationem(thesauriPuellaeStatus.Globalis.IdAnimationisFun);
            _motor = new Motor(ostia.PuellaeLociMut, ostia.PuellaeLociLeg, ostia.TemporisLeg);
        }

        private void InitareAnimationem(IDPuellaeAnimationisFundamenti idFundamenti) {
            _osAnimationesMut.CogereFundamenti(idFundamenti, null, false);
            _osAnimationesMut.CogereDesinentiamCorporis();
        }

        public void Opero() {
            // 状態更新を検証
            MutareStatumCorporis();

            // アニメーションを更新
            // 状態更新適用(ApplicareMutationis)は
            // PostulareCorporisによってコールバックとして実行される。
            MutareAnimationisCorporis();

            // 移動計画を作成
            OrdinatioMotus ordinatio = OrdinareMotum();

            _motor.ApplicareMotus(ordinatio);

            RenovareFuluidaMotus();

            _osAnimationesMut.InjicereVelocitatem(
                _resFuluidaMotus.VelocitasActualisHorizontal
            );
        }

        private void RenovareFuluidaMotus() {
            _resFuluidaMotus.Renovare(
                _osPuellaeLociLeg.VelHorizontalisActualis,
                _osPuellaeLociLeg.VelVerticalisActualis,
                _osPuellaeLociLeg.RotatioYActualis,
                true // TODO: 現状、ジャンプ無。EstInTerraは常にtrue。
            );
        }

        private OrdinatioMotus OrdinareMotum() {
            return _statusCorporisActualis.Ordinare(_resFuluidaMotusLeg);
        }

        private void MutareStatumCorporis() {
            IDStatus prox = _statusCorporisActualis.MutareStatum(_resFuluidaMotusLeg);
            if (_statusCorporisActualis.Id != prox) {
                _statusProximus = prox;
            } else {
                _statusProximus = IDStatus.None;
            }
        }

        private void MutareAnimationisCorporis() {
            if (_statusProximus == IDStatus.None) {
                return;
            }
            IDPuellaeAnimationisCorporis idAnimationisProximus = 
                _tabulaStatuumCorporis.Lego(_statusProximus).IdAnimationis;
            _osAnimationesMut.PostulareCorporis(
                idAnimationisProximus, _fInvocanda, false
            );
        }

        private void ApplicareMutationis() {
            if (_statusProximus == IDStatus.None) {
                return;
            }
            _statusCorporisActualis.Exire(_resFuluidaMotusLeg);
            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(_statusProximus);
            _statusCorporisActualis.Intrare(_resFuluidaMotusLeg);
        }
    }
}
