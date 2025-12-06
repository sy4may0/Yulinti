using Yulinti.Dux.Miles;
using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
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

        private Action _fInvocanda; // LuditorAnimationis縺ｫ貂｡縺吶さ繝ｼ繝ｫ繝舌ャ繧ｯ

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

        private void InitareAnimationem(IDPuellaeAnimationisContinuata idContinuata) {
            _osAnimationesMut.Cogere(idContinuata, null, null);
        }

        public void Opero() {
            // 迥ｶ諷区峩譁ｰ繧呈､懆ｨｼ
            MutareStatumCorporis();

            // 繧｢繝九Γ繝ｼ繧ｷ繝ｧ繝ｳ繧呈峩譁ｰ
            // 迥ｶ諷区峩譁ｰ驕ｩ逕ｨ(ApplicareMutationis)縺ｯ
            // PostulareCorporis縺ｫ繧医▲縺ｦ繧ｳ繝ｼ繝ｫ繝舌ャ繧ｯ縺ｨ縺励※螳溯｡後＆繧後ｋ縲・
            MutareAnimationisCorporis();

            // 遘ｻ蜍戊ｨ育判繧剃ｽ懈・
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
                true // TODO: 迴ｾ迥ｶ縲√ず繝｣繝ｳ繝礼┌縲・stInTerra縺ｯ蟶ｸ縺ｫtrue縲・
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
            IDPuellaeAnimationisContinuata idAnimationisProximus = 
                _tabulaStatuumCorporis.Lego(_statusProximus).IdAnimationis;
            _osAnimationesMut.Postulare(
                idAnimationisProximus, adInitium: _fInvocanda, adFinem: null
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
